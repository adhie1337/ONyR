using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.User;

namespace ONyR_client.control.commands.User
{
    class AddUsersCommand : Command<AddUsersNotifier>
    {
        override protected void execute(AddUsersNotifier pAddUsersNotifier)
        {
            new UserServiceDelegate(
                    pAddUsersNotifier,
                    new UserServiceResponder()
                ).AddUsers(pAddUsersNotifier.Users);
        }
    }
}
