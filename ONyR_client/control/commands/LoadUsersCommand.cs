using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.control.notifiers;
using ONyR_client.control.business.delegates;

namespace ONyR_client.control.commands
{
    class LoadUsersCommand : Command<LoadUsersNotifier>
    {
        override protected void execute(LoadUsersNotifier pLoadUsersNotifier)
        {
            UserServiceDelegate.LoadUsers((UserServiceSkeleton.UserFilter)pLoadUsersNotifier.Filter, pLoadUsersNotifier.Id, pLoadUsersNotifier.Ids);
        }
    }
}
