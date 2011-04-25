using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONyR_client.control.notifiers
{
    class LoadUsersNotifier : Notifier
    {
        public enum UserFilter
        {
            ById=0, ByIds, All
        };

        public LoadUsersNotifier(UserFilter pFilter, int pId = -1, int[] pIds = null)
        {
            mfeFilter = pFilter;
            miId = pId;
            maIds = pIds;
        }

        private UserFilter mfeFilter;
        private int miId;
        private int[] maIds;

        public UserFilter Filter
        {
            get
            {
                return mfeFilter;
            }
        }

        public int Id
        {
            get
            {
                if (mfeFilter == UserFilter.ById)
                {
                    return miId;
                }

                return -1;
            }
        }

        public int[] Ids
        {
            get
            {
                if (mfeFilter == UserFilter.ByIds)
                {
                    return maIds;
                }

                return null;
            }
        }
    }
}
