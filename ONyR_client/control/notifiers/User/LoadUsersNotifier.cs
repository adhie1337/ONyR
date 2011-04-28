namespace ONyR_client.control.notifiers.User
{
    class LoadUsersNotifier : Notifier
    {
        public enum UserFilter
        {
            ById=0, ByIds, All
        };

        public LoadUsersNotifier(UserFilter pFilter, int pId = -1, int[] pIds = null)
        {
            mFilter = pFilter;
            mId = pId;
            mIds = pIds;
        }

        private UserFilter mFilter;
        private int mId;
        private int[] mIds;

        public UserFilter Filter
        {
            get
            {
                return mFilter;
            }
        }

        public int Id
        {
            get
            {
                if (mFilter == UserFilter.ById)
                {
                    return mId;
                }

                return -1;
            }
        }

        public int[] Ids
        {
            get
            {
                if (mFilter == UserFilter.ByIds)
                {
                    return mIds;
                }

                return null;
            }
        }


        override public object Clone()
        {
            return new LoadUsersNotifier(mFilter, mId, mIds);
        }
    }
}
