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
    class LogoutUserCommand : Command<LogoutUserNotifier>
    {
        override protected void execute(LogoutUserNotifier pLogoutUserNotifier)
        {
            AuthenticationServiceDeleage.Logout();
        }
    }
}
