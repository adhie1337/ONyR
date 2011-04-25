using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.AuthenticationServiceSkeleton;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using ONyR_client.model;
using ONyR_client.control.business.responders;

namespace ONyR_client.control.business.delegates
{
    class AuthenticationServiceDeleage
    {
        public static void Login(string username, string password)
        {
            bool retVal = false;

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);

            retVal = client.Login(username, password, null, false);

            if (retVal)
            {
                MessageProperties props = OperationContext.Current.IncomingMessageProperties;
                HttpResponseMessageProperty prop = props[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                string rawCookies = prop.Headers[HttpResponseHeader.SetCookie];

                AuthenticationServiceResponder.LoginResult(FormatCookie(rawCookies));
            }
            else
            {
                AuthenticationServiceResponder.LoginFault();
            }

            client.Close();
        }

        public static void Logout()
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, ModelLocator.getInstance().SessionModel.SessionCookie);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            try
            {
                client.Logout();
                AuthenticationServiceResponder.LogoutResult();
            }
            catch (Exception)
            {
                AuthenticationServiceResponder.LogoutFault();
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        public static bool IsLoggedIn()
        {
            bool retVal = false;

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, ModelLocator.getInstance().SessionModel.SessionCookie);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

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
