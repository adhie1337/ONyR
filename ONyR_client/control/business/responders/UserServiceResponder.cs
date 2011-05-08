using ONyR_client.model;
using ONyR_client.model.vo;
using ONyR_client.model.models;
using System.Windows.Forms;
using ONyR_client.view;
using ONyR_client.UserServiceReference;

namespace ONyR_client.control.business.responders
{
    class UserServiceResponder : Responder
    {

        private ONyR_client.model.vo.UserVO[] Convert(ONyR_client.UserServiceReference.UserVO[] originals)
        {
            ONyR_client.model.vo.UserVO[] serialized = new ONyR_client.model.vo.UserVO[originals.Length];

            for (int i = 0; i < originals.Length; ++i)
            {
                serialized[i] = new model.vo.UserVO().FillFromServiceReference(originals[i]);
            }

            return serialized;
        }


        public void LoadUsersResult(object sender, LoadUsersCompletedEventArgs e)
        {
            ONyR_client.model.vo.UserVO[] loadedUsers = Convert(e.Result);
            SessionModel sessionModel = ModelLocator.getInstance().SessionModel;
            foreach (ONyR_client.model.vo.UserVO user in loadedUsers)
            {
                if (sessionModel.UserId == user.ID)
                {
                    sessionModel.SetCurrentUser(user);
                    break;
                }
            }
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();

            ModelLocator.getInstance().UserModel.AddUsers(loadedUsers);
        }

        public void LoadUsersFault(ErrorCode pCode)
        {
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void AddUsersResult(object sender, AddUsersCompletedEventArgs e)
        {
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
            ONyR_client.model.vo.UserVO[] addedUsers = Convert(e.Result);
            ModelLocator.getInstance().UserModel.AddUsers(addedUsers);
        }

        public void AddUsersFault(ErrorCode pCode)
        {
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void RemoveUsersResult(object sender, RemoveUsersCompletedEventArgs e)
        {
            ONyR_client.model.vo.UserVO[] removedUsers = Convert(e.Result);
            ModelLocator locator = ModelLocator.getInstance();
            int[] ids = new int[removedUsers.Length];

            for (int i = 0; i < removedUsers.Length; ++i)
            {
                ids[i] = removedUsers[i].ID;
            }
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();

            locator.UserModel.RemoveUsersByIDs(ids);
        }

        public void RemoveUserFault(ErrorCode pCode)
        {
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void ModifyUsersResult(object sender, ModifyUsersCompletedEventArgs e)
        {
            ONyR_client.model.vo.UserVO[] newUsers = Convert(e.Result);
            SessionModel sessionModel = ModelLocator.getInstance().SessionModel;
            foreach (ONyR_client.model.vo.UserVO user in newUsers)
            {
                if (sessionModel.UserId == user.ID)
                {
                    sessionModel.SetCurrentUser(user);
                    break;
                }
            }
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
            ModelLocator.getInstance().UserModel.ModifyUsers(newUsers);
        }

        public void ModifyUsersFault(ErrorCode pCode)
        {
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
            ApplicationFaultManager.Fault(pCode, Initiator);
        }

        public void ModifyPasswordResult()
        {
            MessageBox.Show("A jelszó módosítása sikeres!", "Információ", MessageBoxButtons.OK);

            if (ChangePasswordForm.hasInstance())
            {
                ChangePasswordForm.getCurrentInstance().Close();
            }
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
        }

        public void ModifyPasswordFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode, Initiator);
            ModelLocator.getInstance().SessionModel.NotifyOneOperationDone();
        }

    }
}
