using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.User;

namespace ONyR_client.control.commands.User
{
    class LoadUsersCommand : Command<LoadUsersNotifier>
    {
        override protected void execute(LoadUsersNotifier pLoadUsersNotifier)
        {
            new UserServiceDelegate(
                pLoadUsersNotifier,
                new UserServiceResponder()
            ).LoadUsers((UserServiceSkeleton.UserFilter)pLoadUsersNotifier.Filter, pLoadUsersNotifier.Id, pLoadUsersNotifier.Ids);
        }
    }
}
