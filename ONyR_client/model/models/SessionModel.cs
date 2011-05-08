using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.vo;
using ONyR_client.control;
using ONyR_client.control.notifiers.User;
using ONyR_client.view;

namespace ONyR_client.model.models
{
    public class SessionModel : Model, IONyRObservable<ApplicationState>
    {

        #region Members

        private string mSessionCookie = null;
        private int mSessionId = -1;
        private int mUserId = -1;
        private string mASPSessionId = null;
        private UserVO mCurrentUser = null;
        private List<IONyRObserver<ApplicationState>> mObservers;
        private int mOperationsLoading = 0;

        #endregion

        #region Constructor

        public SessionModel()
        {
        }

        #endregion

        #region Properties

        public bool IsLoggedIn
        {
            get
            {
                return mSessionId != -1 || CurrentUser != null;
            }
        }

        public string SessionCookie
        {
            get
            {
                return mSessionCookie;
            }
        }

        public int SessionId
        {
            get
            {
                return mSessionId;
            }
        }

        public int UserId
        {
            get
            {
                return mUserId;
            }
        }

        public string ASPSessionId
        {
            get
            {
                return mASPSessionId;
            }
        }

        public UserVO CurrentUser
        {
            get
            {
                return mCurrentUser;
            }
        }

        public ApplicationState CurrentState
        {
            get
            {
                if (mOperationsLoading > 0)
                {
                    return ApplicationState.Loading;
                }
                else if (!IsLoggedIn)
                {
                    return ApplicationState.Offline;
                }
                else if (CurrentUser == null)
                {
                    return ApplicationState.Anonimous;
                }
                else
                {
                    return ApplicationState.Online;
                }
            }
        }

        #endregion

        #region Model manipulation

        public void NotifyOneOperationBegin()
        {
            ++mOperationsLoading;
            update();
        }

        public void NotifyOneOperationDone()
        {
            if (mOperationsLoading > 0)
            {
                --mOperationsLoading;
            }
            update();
        }

        public void Logout()
        {
            mCurrentUser = null;
            mSessionCookie =
            mASPSessionId = null;
            mSessionId = -1;
            mUserId = -1;
            update();
        }

        public void SetSessionCookie(string pCookie)
        {
            mSessionCookie = pCookie;
            string[] cookies = pCookie.Split(new char[] { ',', ';' });

            foreach (string entry in cookies)
            {
                if (entry.Trim().StartsWith("UserId="))
                {
                    mUserId = Int32.Parse(entry.Trim().Substring(7).Trim());
                    new LoadUsersNotifier(
                        LoadUsersNotifier.UserFilter.ById,
                        mUserId
                    ).Handle();
                }
                else if (entry.Trim().StartsWith("SessionId="))
                {
                    mSessionId = Int32.Parse(entry.Trim().Substring(10).Trim());
                }
                else if (entry.Trim().StartsWith("ASP.NET_SessionId="))
                {
                    mASPSessionId = entry.Trim().Substring(18).Trim();
                }
            }

            update();
        }

        public void SetCurrentUser(UserVO pCurrentUser)
        {
            mCurrentUser = pCurrentUser;
            update();
        }

        #endregion

        #region IONyRObservable<ApplicationState> Members

        public void Subscribe(IONyRObserver<ApplicationState> observer)
        {
            if (mObservers == null)
            {
                mObservers = new List<IONyRObserver<ApplicationState>>();
            }

            mObservers.Add(observer);
        }

        public void RefreshObservers()
        {
            if (mObservers != null)
            {
                foreach (IONyRObserver<ApplicationState> o in mObservers)
                {
                    o.Refresh(CurrentState);
                }
            }
        }

        #endregion

        #region Overridden methods

        protected override void update()
        {
            base.update();

            RefreshObservers();
        }

        #endregion
    }
}
