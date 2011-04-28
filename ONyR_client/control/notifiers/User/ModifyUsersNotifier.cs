using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.User
{
    class ModifyUsersNotifier : Notifier
    {
        private UserVO[] mOriginalUsers;

        private UserVO[] mModifiedUsers;

        public ModifyUsersNotifier(UserVO[] pOriginalUsers, UserVO[] pModifiedUsers)
        {
            mOriginalUsers = pOriginalUsers;
            mModifiedUsers = pModifiedUsers;
        }

        public UserVO[] OriginalUsers
        {
            get
            {
                return mOriginalUsers;
            }
        }

        public UserVO[] ModifiedUsers
        {
            get
            {
                return mModifiedUsers;
            }
        }

        public override object Clone()
        {
            return new ModifyUsersNotifier(mOriginalUsers, mModifiedUsers);
        }
    }
}
