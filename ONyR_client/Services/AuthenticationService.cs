﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.AuthenticationServiceSkeleton;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace ONyR_client.Services
{
    class AuthenticationService
    {
        public static bool Login(string username, string password, string customCredential = null, Boolean isPersistent = false)
        {
            bool retVal = false;

            if (IsLoggedIn())
            {
                Logout();
            }

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);

            retVal = client.Login(username, password, customCredential, isPersistent);

            if(retVal)
            {
                //* Retrieve the cookie that is returned in the response
                MessageProperties props = OperationContext.Current.IncomingMessageProperties;
                HttpResponseMessageProperty prop = props[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                string rawCookies = prop.Headers[HttpResponseHeader.SetCookie];

                //* Adjust the cookie into something we can send back to the services (see function below)
                SessionCookieContainer.cookies = FormatCookie(rawCookies);
            }

            client.Close();

            return retVal;
        }

        public static void Logout()
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, SessionCookieContainer.cookies);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            //* Make the data services call - the cookie will be sent and the client authenticated
            client.Logout();

            SessionCookieContainer.cookies = null;

            client.Close();
        }

        public static bool IsLoggedIn()
        {
            bool retVal = false;

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, SessionCookieContainer.cookies);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            //* Make the data services call - the cookie will be sent and the client authenticated
            retVal = client.IsLoggedIn();

            client.Close();

            return retVal;
        }

        /// <summary>
        /// Formats a request cookie string from the cookies received from the authentication service
        /// </summary>
        /// <param name="input">The cookie string received from the authentications service</param>
        /// <returns>A formatted cookie string to send to data requests</returns>
        private static string FormatCookie(string input)
        {
            string[] cookies = input.Split(new char[] { ',', ';' });
            StringBuilder buffer = new StringBuilder(input.Length * 10);
            foreach (string entry in cookies)
            {
                if (entry.IndexOf("=") > 0 && !entry.Trim().StartsWith("path") && !entry.Trim().StartsWith("expires"))
                {
                    buffer.Append(entry).Append("; ");
                }
            }
            if (buffer.Length > 0)
            {
                buffer.Remove(buffer.Length - 2, 2);
            }
            return buffer.ToString();
        }
    }
}