using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control;
using ONyR_client.control.commands.Session;
using ONyR_client.control.notifiers.Session;

namespace ONyR_client.control
{
    class SessionController : FrontController
    {
        override protected void Initialize()
        {
            base.addConnection(typeof(LoginUserNotifier), typeof(LoginUserCommand));
            base.addConnection(typeof(LogoutUserNotifier), typeof(LogoutUserCommand));
        }
    }
}
