using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.models;
using ONyR_client.model;

namespace ONyR_client.control.business.responders
{
    class AuthenticationServiceResponder : Responder
    {
        public void LoginResult(string cookie)
        {
            ModelLocator.getInstance().SessionModel.SetSessionCookie(cookie);
        }

        public void LoginFault(ErrorCode pCode)
        {
            ModelLocator.getInstance().SessionModel.Logout();
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void LogoutResult()
        {
            ModelLocator.getInstance().SessionModel.Logout();
        }

        public void LogoutFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode, Initiator);
        }
    }
}
