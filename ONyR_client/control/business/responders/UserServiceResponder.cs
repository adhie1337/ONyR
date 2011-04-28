using ONyR_client.model;
using ONyR_client.model.vo;

namespace ONyR_client.control.business.responders
{
    class UserServiceResponder : Responder
    {
        public void LoadUsersResult(UserVO[] pLoadedUsers)
        {
            ModelLocator locator = ModelLocator.getInstance();

            for (int i = 0; i < pLoadedUsers.Length; ++i)
            {
                if (pLoadedUsers[i].ID == locator.SessionModel.UserId)
                {
                    locator.SessionModel.SetCurrentUser(pLoadedUsers[i]);
                }
            }

            locator.UserModel.AddUsers(pLoadedUsers);
        }

        public void LoadUsersFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void AddUsersResult(UserVO[] pAddedUsers)
        {
            ModelLocator.getInstance().UserModel.AddUsers(pAddedUsers);
        }

        public void AddUsersFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void RemoveUsersResult(UserVO[] pRemovedUsers)
        {
            ModelLocator locator = ModelLocator.getInstance();
            int[] ids = new int[pRemovedUsers.Length];

            for (int i = 0; i < pRemovedUsers.Length; ++i)
            {
                ids[i] = pRemovedUsers[i].ID;
            }

            locator.UserModel.RemoveUsersByIDs(ids);
        }

        public void RemoveUsersFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void ModifyUsersResult(UserVO[] pNewUsers)
        {
            ModelLocator.getInstance().UserModel.ModifyUsers(pNewUsers);
        }

        public void ModifyUsersFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

    }
}
