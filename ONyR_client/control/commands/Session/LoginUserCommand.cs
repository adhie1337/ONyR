using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control;
using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.Session;
using ONyR_client.model;

namespace ONyR_client.control.commands.Session
{
    class LoginUserCommand : Command<LoginUserNotifier>
    {
        override protected void execute(LoginUserNotifier pLoginUserNotifier)
        {
            if (ModelLocator.getInstance().SessionModel.IsLoggedIn)
            {
                new AuthenticationServiceDeleage(
                        pLoginUserNotifier,
                        new AuthenticationServiceResponder()
                    ).Logout();
            }

            new AuthenticationServiceDeleage(
                       pLoginUserNotifier,
                       new AuthenticationServiceResponder()
                   ).Login(pLoginUserNotifier.UserName, pLoginUserNotifier.Password);
        }
    }
}
