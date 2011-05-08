using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ONyR_client.model
{
    public abstract class Model
    {
        public delegate void UpdateHandler(object pSender, EventArgs e);

        public event UpdateHandler UpdateEvent;

        protected virtual void update()
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, EventArgs.Empty);
            }
        }
    }


    public interface IValueObject<VOClass>
    {
        VOClass Clone();
        VOClass FillFromServiceReference(object pReference);
        VOState GetState();
        bool StateIsEqualTo(VOState pState);
        void SetState(VOState pState);
    }

    public class VOStateManager
    {
        private string[] mPropertyNames;
        private object mValueObjectInstance;
        private VOState mLastStoredState;

        public VOStateManager(string[] pPropertyNames, object pValueObjectInstance)
        {
            mPropertyNames = pPropertyNames;
            mValueObjectInstance = pValueObjectInstance;
        }

        public VOState GetState()
        {
            VOState result = new VOState();
            try
            {
                foreach (PropertyInfo info in mValueObjectInstance.GetType().GetProperties())
                {
                    if (info.CanRead && info.CanWrite && mPropertyNames.Contains(info.Name))
                    {
                        result.SetMember(info.Name, info.GetValue(mValueObjectInstance, null));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public void SetState(VOState pState)
        {
            if (pState != null)
            {
                foreach (PropertyInfo info in mValueObjectInstance.GetType().GetProperties())
                {
                    if (info.CanRead && info.CanWrite && mPropertyNames.Contains(info.Name))
                    {
                        info.SetValue(mValueObjectInstance, pState.GetMember(info.Name), null);
                    }
                }
            }
        }

        public void StoreState()
        {
            mLastStoredState = GetState();
        }

        public void RestoreState()
        {
            SetState(mLastStoredState);
        }

        public bool StateIsEqualTo(VOState pState)
        {
            VOState myState = GetState();
            List<string> attributes = myState.GetAttributes();
            List<string> otherAttributes = pState.GetAttributes();

            if (attributes.Count != pState.GetAttributes().Count)
            {
                return false;
            }

            foreach (string attribute in attributes)
            {
                if (!myState.GetMember(attribute).Equals(pState.GetMember(attribute))
                    || !otherAttributes.Remove(attribute))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class VOState
    {
        private Dictionary<string, object> mInternalCollection;

        public VOState()
        {
            mInternalCollection = new Dictionary<string, object>();
        }

        public object GetMember(string pPropertyName)
        {
            if (mInternalCollection.ContainsKey(pPropertyName))
            {
                return mInternalCollection[pPropertyName];
            }

            return null;
        }

        public void SetMember(string pPropertyName, object pPropertyValue)
        {
            mInternalCollection[pPropertyName] = pPropertyValue;
        }

        public List<string> GetAttributes()
        {
            string[] result = new string[mInternalCollection.Keys.Count];
            mInternalCollection.Keys.ToArray().CopyTo(result, 0);
            return new List<string>(result);
        }
    }
}
