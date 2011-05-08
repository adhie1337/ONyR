using System.Collections.Generic;
using System.Linq;
using ONyR_client.model.vo;

namespace ONyR_client.model.models
{
    public class UserModel : Model
    {

        #region Members

        private Dictionary<int, UserVO> mUser;

        #endregion

        #region Constructor

        public UserModel()
        {
            mUser = new Dictionary<int, UserVO>();
        }

        #endregion

        #region Queries

        public UserVO GetUserByID(int pID)
        {
            return mUser[pID].Clone();
        }

        public List<UserVO> GetUsersByIDs(int[] pIDs)
        {
            List<UserVO> result = new List<UserVO>();

            int[] keys = mUser.Keys.ToArray();

            for (int i = 0; i < pIDs.Count(); ++i)
            {
                if (keys.Contains(pIDs[i]))
                {
                    result.Add(mUser[pIDs[i]].Clone());
                }
            }

            return result;
        }

        public List<UserVO> GetAllUsers()
        {
            List<UserVO> result = new List<UserVO>();

            int[] keys = mUser.Keys.ToArray();

            for (int i = 0; i < keys.Count(); ++i)
            {
                result.Add(mUser[keys[i]].Clone());
            }

            return result;
        }

        #endregion

        #region Model manipulation

        public void AddUser(UserVO pUser)
        {
            mUser[pUser.ID] = pUser;
            update();
        }

        public void AddUsers(UserVO[] pUsers)
        {
            foreach (UserVO vo in pUsers)
            {
                mUser[vo.ID] = vo.Clone();
            }

            update();
        }

        public void RemoveUserByID(int pID)
        {
            mUser.Remove(pID);
        }

        public void RemoveUsersByIDs(int[] pIDs)
        {
            for (int i = 0; i < pIDs.Count(); ++i)
            {
                mUser.Remove(pIDs[i]);
            }
            update();
        }

        public void ModifyUser(UserVO pUser)
        {
            AddUser(pUser);
        }

        public void ModifyUsers(UserVO[] pUsers)
        {
            AddUsers(pUsers);
        }


        public void Empty()
        {
            int[] keys = mUser.Keys.ToArray();

            for (int i = 0; i < keys.Count(); ++i)
            {
                mUser.Remove(keys[i]);
            }

            update();
        }

        #endregion
    }
}
