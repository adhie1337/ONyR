using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control;
using ONyR_client.control.notifiers;
using ONyR_client.control.commands;

namespace ONyR_client.control
{
    class UserController : FrontController
    {
        override protected void Initialize()
        {
            addConnection(typeof(LoadUsersNotifier), typeof(LoadUsersCommand));
        }
    }
}
