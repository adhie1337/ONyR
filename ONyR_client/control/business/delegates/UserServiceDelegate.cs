using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.UserServiceSkeleton;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using ONyR_client.model;
using ONyR_client.control.business.responders;

namespace ONyR_client.control.business.delegates
{
    class UserServiceDelegate
    {
        public static void LoadUsers(UserFilter pFilter, int pID = -1, int[] pIDs = null)
        {
            UserServiceClient client = new UserServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, ModelLocator.getInstance().SessionModel.SessionCookie);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            try
            {
                UserVO[] retVal;
                retVal = client.LoadUsers(pFilter, pID, pIDs);
                ONyR_client.model.vo.UserVO[] serialized = new ONyR_client.model.vo.UserVO[retVal.Length];

                for (int i = 0; i < retVal.Length; ++i)
                {
                    serialized[i] = new model.vo.UserVO().FillFromSkeleton(retVal[i]);
                }

                UserServiceResponder.LoadUsersResult(serialized);
            }
            catch (Exception)
            {
                UserServiceResponder.LoadUsersFault();
            }
            finally
            {
                client.Close();
            }
        }
    }
}
