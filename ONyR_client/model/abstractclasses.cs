using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONyR_client.model
{
    public abstract class Model
    {
        public delegate void UpdateHandler(object pSender, EventArgs e);

        public event UpdateHandler UpdateEvent;

        protected void update()
        {
            UpdateEvent(this, EventArgs.Empty);
        }
    }

    public interface IValueObject<VOClass>
    {
        VOClass Clone();
        VOClass FillFromSkeleton(object pSkeleton);
    }
}
