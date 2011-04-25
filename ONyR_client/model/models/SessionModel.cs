using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.vo;
using ONyR_client.control;
using ONyR_client.control.notifiers;

namespace ONyR_client.model.models
{
    class SessionModel : Model
    {

        #region Constructor

        public SessionModel()
        {
        }

        #endregion

        #region Properties

        private string mSessionCookie = null;
        private int mSessionId = -1;
        private int mUserId = -1;
        private string mASPSessionId = null;
        private UserVO mCurrentUser = null;

        public bool IsLoggedIn
        {
            get
            {
                return mSessionId != -1 || CurrentUser != null;
            }
        }

        #endregion

        #region Queries

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


        #endregion

        #region Model manipulation

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
    }
}
