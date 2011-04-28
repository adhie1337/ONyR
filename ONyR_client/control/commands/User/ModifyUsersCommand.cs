using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.User;

namespace ONyR_client.control.commands.User
{
    class ModifyUsersCommand : Command<ModifyUsersNotifier>
    {
        override protected void execute(ModifyUsersNotifier pModifyUsersNotifier)
        {
            new UserServiceDelegate(
                    pModifyUsersNotifier,
                    new UserServiceResponder()
                ).ModifyUsers(pModifyUsersNotifier.OriginalUsers, pModifyUsersNotifier.ModifiedUsers, pModifyUsersNotifier.isForced);
        }
    }
}
