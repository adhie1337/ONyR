using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.User
{
    class RemoveUsersNotifier : Notifier
    {
        public RemoveUsersNotifier(UserVO[] pUsers)
        {
            mUsers = pUsers;
        }

        private UserVO[] mUsers;

        public UserVO[] Users
        {
            get
            {
                return mUsers;
            }
        }

        public override object Clone()
        {
            return new AddUsersNotifier(mUsers);
        }
    }
}
