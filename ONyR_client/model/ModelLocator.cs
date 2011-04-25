using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.models;

namespace ONyR_client.model
{
    class ModelLocator
    {
        #region Singleton design pattern implementation

        private static ModelLocator instance;

        public static ModelLocator getInstance()
        {
            if (instance == null)
            {
                instance = new ModelLocator();
            }
            return instance;
        }

        #endregion

        #region Constructor

        private ModelLocator()
        {
            SessionModel = new SessionModel();
            UserModel = new UserModel();
        }

        #endregion

        #region Models

        public SessionModel SessionModel;
        public UserModel UserModel;

        #endregion
    }
}
