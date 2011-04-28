using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.User;

namespace ONyR_client.control.commands.User
{
    class RemoveUsersCommand : Command<RemoveUsersNotifier>
    {
        override protected void execute(RemoveUsersNotifier pRemoveUsersNotifier)
        {
            new UserServiceDelegate(
                    pRemoveUsersNotifier,
                    new UserServiceResponder()
                ).RemoveUsers(pRemoveUsersNotifier.Users);
        }
    }
}
