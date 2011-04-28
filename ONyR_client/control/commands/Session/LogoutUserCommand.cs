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
    class LogoutUserCommand : Command<LogoutUserNotifier>
    {
        override protected void execute(LogoutUserNotifier pLogoutUserNotifier)
        {
            new AuthenticationServiceDeleage(
                       pLogoutUserNotifier,
                       new AuthenticationServiceResponder()
                   ).Logout();
        }
    }
}
