using ONyR_client.control.notifiers.User;
using ONyR_client.control.commands.User;

namespace ONyR_client.control
{
    class UserController : FrontController
    {
        override protected void Initialize()
        {
            addConnection(typeof(LoadUsersNotifier), typeof(LoadUsersCommand));
            addConnection(typeof(AddUsersNotifier), typeof(AddUsersCommand));
            addConnection(typeof(ModifyUsersNotifier), typeof(ModifyUsersCommand));
            addConnection(typeof(RemoveUsersNotifier), typeof(RemoveUsersCommand));
            addConnection(typeof(ModifyPasswordNotifier), typeof(ModifyPasswordCommand));
        }
    }
}
