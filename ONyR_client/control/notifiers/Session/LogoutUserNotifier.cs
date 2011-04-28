using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control;

namespace ONyR_client.control.notifiers.Session
{
    class LogoutUserNotifier : Notifier
    {
        public LogoutUserNotifier()
        {
        }


        override public object Clone()
        {
            return new LogoutUserNotifier();
        }
    }
}
