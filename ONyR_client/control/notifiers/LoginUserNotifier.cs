using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control;

namespace ONyR_client.control.notifiers
{
    class LoginUserNotifier : Notifier
    {
        private string mUserName;
        private string mPassword;

        public LoginUserNotifier(string pUserName, string pPassword)
        {
            mUserName = pUserName;
            mPassword = pPassword;
        }

        public string UserName
        {
            get
            {
                return mUserName;
            }
        }

        public string Password
        {
            get
            {
                return mPassword;
            }
        }
    }
}
