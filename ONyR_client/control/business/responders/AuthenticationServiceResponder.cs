using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.models;
using ONyR_client.model;

namespace ONyR_client.control.business.responders
{
    class AuthenticationServiceResponder
    {
        public static void LoginResult(string cookie)
        {
            ModelLocator.getInstance().SessionModel.SetSessionCookie(cookie);
        }

        public static void LoginFault()
        {
            ModelLocator.getInstance().SessionModel.Logout();
        }

        public static void LogoutResult()
        {
            ModelLocator.getInstance().SessionModel.Logout();
        }

        public static void LogoutFault()
        {

        }
    }
}
