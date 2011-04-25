using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control;
using ONyR_client.control.business.delegates;
using ONyR_client.control.notifiers;
using ONyR_client.model;

namespace ONyR_client.control.commands
{
    class LoginUserCommand : Command<LoginUserNotifier>
    {
        override protected void execute(LoginUserNotifier pLoginUserNotifier)
        {
            if (ModelLocator.getInstance().SessionModel.IsLoggedIn)
            {
                AuthenticationServiceDeleage.Logout();
            }

            AuthenticationServiceDeleage.Login(pLoginUserNotifier.UserName, pLoginUserNotifier.Password);
        }
    }
}
