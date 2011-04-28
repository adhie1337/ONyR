using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.User
{
    class AddUsersNotifier : Notifier
    {
        public AddUsersNotifier(UserVO[] pUsers)
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

        override public object Clone()
        {
            return new AddUsersNotifier(mUsers);
        }
    }
}
