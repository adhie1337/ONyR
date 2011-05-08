using ONyR_client.utils;
namespace ONyR_client.model.vo
{
    public class UserVO : UserServiceReference.UserVO, IValueObject<UserVO>
    {
        public UserVO Clone()
        {
            return new UserVO().FillFromServiceReference(this);
        }

        public UserVO FillFromServiceReference(object pReference)
        {
            UserServiceReference.UserVO other = (UserServiceReference.UserVO)pReference;

            ID = other.ID;
            UserName = other.UserName;
            Title = other.Title;
            FirstName = other.FirstName;
            MiddleName = other.MiddleName;
            LastName = other.LastName;
            MothersMaidenName = other.MothersMaidenName;
            EMail = other.EMail;
            IdentityCardNumber = other.IdentityCardNumber;
            LastLogin = other.LastLogin;

            return this;
        }

        private VOStateManager mStateManager;

        private VOStateManager StateManager
        {
            get
            {
                if (mStateManager == null)
                {
                    mStateManager = new VOStateManager(new string[] { "ID", "UserName", "Title", "FirstName", "MiddleName", "LastName", "MothersMaidenName", "EMail", "IdentityCardNumber", "LastLogin" }, this);
                }
                return mStateManager;
            }
        }

        public VOState GetState()
        {
            return StateManager.GetState();
        }

        public void SetState(VOState pState)
        {
            StateManager.SetState(pState);
        }

        public void StoreState()
        {
            StateManager.StoreState();
        }

        public void RestoreState()
        {
            StateManager.RestoreState();
        }

        public bool StateIsEqualTo(VOState pState)
        {
            return StateManager.StateIsEqualTo(pState);
        }

        public string Name
        {
            get
            {
                return UserNameFormatter.Format(this);
            }
        }
    }
}
