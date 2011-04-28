using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ONyR_client.control.business.responders;
using ONyR_client.model;
using ONyR_client.UserServiceSkeleton;

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
            UserServiceClient retVal = new UserServiceClient();
            OperationContextScope scope = new OperationContextScope(retVal.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, ModelLocator.getInstance().SessionModel.SessionCookie);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            return retVal;
        }

        private ONyR_client.model.vo.UserVO[] Convert(UserVO[] originals)
        {
            ONyR_client.model.vo.UserVO[] serialized = new ONyR_client.model.vo.UserVO[originals.Length];

            for (int i = 0; i < originals.Length; ++i)
            {
                serialized[i] = new model.vo.UserVO().FillFromSkeleton(originals[i]);
            }

            return serialized;
        }

        public void LoadUsers(UserFilter pFilter, int pID = -1, int[] pIDs = null)
        {
            UserServiceClient client = GetClient();

            try
            {
                UserVO[] retVal = client.LoadUsers(pFilter, pID, pIDs);
                mResponder.LoadUsersResult(Convert(retVal));
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

        public void AddUsers(UserVO[] pUsers)
        {
            UserServiceClient client = GetClient();

            try
            {
                client.AddUsers(pUsers);
                mResponder.AddUsersResult(Convert(pUsers));
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

        public void RemoveUsers(UserVO[] pUsers)
        {
            UserServiceClient client = GetClient();

            try
            {
                client.RemoveUsers(pUsers);
                mResponder.RemoveUsersResult(Convert(pUsers));
            }
            catch (FaultException<ONyRFaultException> ex)
            {
                mResponder.RemoveUsersFault((ErrorCode)ex.Detail.ErrorCode);
            }
            catch (Exception)
            {
                mResponder.RemoveUsersFault(ErrorCode.NonONyRError);
            }
            finally
            {
                client.Close();
            }
        }

        public void ModifyUsers(UserVO[] pOriginalUsers, UserVO[] pNewUsers, bool isForced = false)
        {
            UserServiceClient client = GetClient();

            try
            {
                client.ModifyUsers(pOriginalUsers, pNewUsers, isForced);
                mResponder.ModifyUsersResult(Convert(pNewUsers));
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
    }
}
