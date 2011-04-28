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
    class AuthenticationServiceDeleage : Delegate<AuthenticationServiceResponder>
    {
        public AuthenticationServiceDeleage(Notifier pInitiator, AuthenticationServiceResponder pResponder)
            : base(pInitiator, pResponder)
        {
            pResponder.Initiator = pInitiator;
        }

        public void Login(string username, string password)
        {
            bool retVal = false;

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);

            try{

            retVal = client.Login(username, password, null, false);
                MessageProperties props = OperationContext.Current.IncomingMessageProperties;
                HttpResponseMessageProperty prop = props[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                string rawCookies = prop.Headers[HttpResponseHeader.SetCookie];

                mResponder.LoginResult(FormatCookie(rawCookies));
            }
            catch(Exception ex)
            {
                int code;
                ErrorCode errorCode = ErrorCode.NonONyRError;

                try
                {
                    code = System.Convert.ToInt32(ex.Message);
                    errorCode = (ErrorCode)code;
                }
                catch (Exception)
                {
                    // If it was not our Exception, we handle an "Unknown Exception".
                    errorCode = ErrorCode.NonONyRError;
                }

                mResponder.LoginFault(errorCode);
            }

            client.Close();
        }

        public void Logout()
        {
            AuthenticationServiceClient client = new AuthenticationServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, ModelLocator.getInstance().SessionModel.SessionCookie);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            try
            {
                client.Logout();
                mResponder.LogoutResult();
            }
            catch (Exception ex)
            {
                int code;
                ErrorCode errorCode = ErrorCode.NonONyRError;

                try
                {
                    code = System.Convert.ToInt32(ex.Message);
                    errorCode = (ErrorCode)code;
                }
                catch (Exception)
                {
                    // If it was not our Exception, we handle an "Unknown Exception".
                    errorCode = ErrorCode.NonONyRError;
                }

                mResponder.LogoutFault(errorCode);
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
