using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ONyR_client.control.business.responders;
using ONyR_client.model;
using ONyR_client.UserServiceReference;

namespace ONyR_client.control.business.delegates
{
    class UserServiceDelegate : Delegate<UserServiceResponder>
    {
        public UserServiceDelegate(Notifier pInitiator, UserServiceResponder responder)
            : base(pInitiator, responder)
        {
            responder.Initiator = pInitiator;
        }

        private UserServiceClient GetClient()
        {
            UserServiceClient result = new UserServiceClient();
            OperationContextScope scope = new OperationContextScope(result.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, ModelLocator.getInstance().SessionModel.SessionCookie);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            return result;
        }

        private ONyR_client.model.vo.UserVO[] Convert(UserVO[] originals)
        {
            ONyR_client.model.vo.UserVO[] serialized = new ONyR_client.model.vo.UserVO[originals.Length];

            for (int i = 0; i < originals.Length; ++i)
            {
                serialized[i] = new model.vo.UserVO().FillFromServiceReference(originals[i]);
            }

            return serialized;
        }

        private UserVO[] ConvertToServer(UserVO[] originals)
        {
            UserVO[] serialized = new UserVO[originals.Length];

            for (int i = 0; i < originals.Length; ++i)
            {
                serialized[i] = new UserVO();
                serialized[i].ID = originals[i].ID;
                serialized[i].UserName = originals[i].UserName;
                serialized[i].Title = originals[i].Title;
                serialized[i].FirstName = originals[i].FirstName;
                serialized[i].MiddleName = originals[i].MiddleName;
                serialized[i].LastName = originals[i].LastName;
                serialized[i].MothersMaidenName = originals[i].MothersMaidenName;
                serialized[i].EMail = originals[i].EMail;
                serialized[i].IdentityCardNumber = originals[i].IdentityCardNumber;
                serialized[i].LastLogin = originals[i].LastLogin;
            }

            return serialized;
        }

        public void LoadUsers(UserFilter pFilter, int pID = -1, int[] pIDs = null)
        {
            UserServiceClient client = GetClient();

            try
            {
                ModelLocator.getInstance().SessionModel.NotifyOneOperationBegin();
                client.LoadUsersCompleted += new EventHandler<LoadUsersCompletedEventArgs>(mResponder.LoadUsersResult);
                client.LoadUsersAsync(pFilter, pID, pIDs);
            }
            catch (FaultException<ONyRFaultException> ex)
            {
                mResponder.LoadUsersFault((ErrorCode)ex.Detail.ErrorCode);
            }
            catch (Exception)
            {
                mResponder.LoadUsersFault(ErrorCode.NonONyRError);
            }
            finally
            {
                client.Close();
            }
        }

        public void AddUsers(UserVO[] pUser)
        {
            UserServiceClient client = GetClient();

            try
            {
                ModelLocator.getInstance().SessionModel.NotifyOneOperationBegin();
                client.AddUsersCompleted += new EventHandler<AddUsersCompletedEventArgs>(mResponder.AddUsersResult);
                client.AddUsersAsync(ConvertToServer(pUser));
            }
            catch (FaultException<ONyRFaultException> ex)
            {
                mResponder.AddUsersFault((ErrorCode)ex.Detail.ErrorCode);
            }
            catch (Exception)
            {
                mResponder.AddUsersFault(ErrorCode.NonONyRError);
            }
            finally
            {
                client.Close();
            }
        }

        public void RemoveUsers(UserVO[] pUser)
        {
            UserServiceClient client = GetClient();

            try
            {
                ModelLocator.getInstance().SessionModel.NotifyOneOperationBegin();
                client.RemoveUsersCompleted += new EventHandler<RemoveUsersCompletedEventArgs>(mResponder.RemoveUsersResult);
                client.RemoveUsersAsync(ConvertToServer(pUser));
            }
            catch (FaultException<ONyRFaultException> ex)
            {
                mResponder.RemoveUserFault((ErrorCode)ex.Detail.ErrorCode);
            }
            catch (Exception)
            {
                mResponder.RemoveUserFault(ErrorCode.NonONyRError);
            }
            finally
            {
                client.Close();
            }
        }

        public void ModifyUsers(UserVO[] pOriginalUser, UserVO[] pNewUser, bool isForced = false)
        {
            UserServiceClient client = GetClient();

            try
            {
                ModelLocator.getInstance().SessionModel.NotifyOneOperationBegin();
                client.ModifyUsersCompleted += new EventHandler<ModifyUsersCompletedEventArgs>(mResponder.ModifyUsersResult);
                client.ModifyUsersAsync(ConvertToServer(pOriginalUser), ConvertToServer(pNewUser), isForced);
            }
            catch (FaultException<ONyRFaultException> ex)
            {
                mResponder.ModifyUsersFault((ErrorCode)ex.Detail.ErrorCode);
            }
            catch (Exception)
            {
                mResponder.ModifyUsersFault(ErrorCode.NonONyRError);
            }
            finally
            {
                client.Close();
            }
        }

        public void ModifyPassword(string pOldPassword, string pNewPassword)
        {
            UserServiceClient client = GetClient();

            try
            {
                ModelLocator.getInstance().SessionModel.NotifyOneOperationBegin();
                client.ModifyPassword(pOldPassword, pNewPassword);
                mResponder.ModifyPasswordResult();
            }
            catch (FaultException<ONyRFaultException> ex)
            {
                mResponder.ModifyPasswordFault((ErrorCode)ex.Detail.ErrorCode);
            }
            catch (Exception)
            {
                mResponder.ModifyPasswordFault(ErrorCode.NonONyRError);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
