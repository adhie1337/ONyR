using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.vo;

namespace ONyR_client.model.models
{
    class UserModel : Model
    {

        #region Constructor

        public UserModel()
        {
            mUsers = new List<UserVO>();
        }

        #endregion

        #region Properties

        private List<UserVO> mUsers;

        #endregion

        #region Queries

        public UserVO GetUserByID(int pID)
        {
            for (int i = 0; i < mUsers.Count; ++i)
            {
                if (mUsers[i].ID == pID)
                {
                    return mUsers[i].Clone();
                }
            }

            return null;
        }

        public List<UserVO> GetUsersByIDs(int[] pIDs)
        {
            List<UserVO> retVal = new List<UserVO>();

            for (int i = 0; i < mUsers.Count; ++i)
            {
                if (pIDs.Contains(mUsers[i].ID))
                {
                    retVal.Add(mUsers[i].Clone());
                }
            }

            return retVal;
        }

        public List<UserVO> GetAllUsers()
        {
            List<UserVO> retVal = new List<UserVO>();

            for (int i = 0; i < mUsers.Count; ++i)
            {
                retVal.Add(mUsers[i].Clone());
            }

            return retVal;
        }

        #endregion

        #region Model manipulation

        public void AddUser(UserVO pUser)
        {
            mUsers.Add(pUser);
            update();
        }

        public void AddUsers(UserVO[] pUsers)
        {
            mUsers.AddRange(pUsers);
            update();
        }

        public void RemoveUserByID(int pID)
        {
            for (int i = 0; i < mUsers.Count; ++i)
            {
                if (mUsers[i].ID == pID)
                {
                    mUsers.RemoveAt(i);
                    update();
                    break;
                }
            }
        }

        public void RemoveUsersByIDs(int[] pIDs)
        {
            for (int i = 0; i < mUsers.Count; ++i)
            {
                if (pIDs.Contains(mUsers[i].ID))
                {
                    mUsers.RemoveAt(i);
                    --i;
                }
            }
            update();
        }

        public void ModifyUser(UserVO pUser)
        {
            for (int i = 0; i < mUsers.Count; ++i)
            {
                if (mUsers[i].ID == pUser.ID)
                {
                    mUsers.RemoveAt(i);
                    break;
                }
            }

            mUsers.Add(pUser);
            update();
        }

        public void ModifyUsers(UserVO[] pUsers)
        {
            for (int i = 0; i < mUsers.Count; ++i)
            {
                if (pUsers.Contains(mUsers[i]))
                {
                    mUsers.RemoveAt(i);
                    --i;
                }
            }

            mUsers.AddRange(pUsers);
            update();
        }


        public void Empty()
        {
            mUsers.RemoveRange(0, mUsers.Count);
            update();
        }

        #endregion
    }
}
