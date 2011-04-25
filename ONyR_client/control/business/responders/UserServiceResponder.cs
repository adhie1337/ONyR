using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.models;
using ONyR_client.model.vo;
using ONyR_client.model;

namespace ONyR_client.control.business.responders
{
    class UserServiceResponder
    {
        public static void LoadUsersResult(UserVO[] pLoadedUsers)
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

        public static void LoadUsersFault()
        {

        }

    }
}
