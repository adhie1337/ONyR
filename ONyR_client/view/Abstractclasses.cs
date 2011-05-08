using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using ONyR_client.model;

namespace ONyR_client.view
{
    public enum EditingState
    {
        NonEditing = 0, Editing, EditingNew
    }

    public class HighlighterForm : Form
    {
        protected HighlightableControl hcHighlightedControl;
        protected Panel pnlHighlightedItemContainer;

        public bool Highlight(HighlightableControl control)
        {
            clearHighlight();

            hcHighlightedControl = control;
            HighlightedItemContainer.Controls.Add(hcHighlightedControl);
            hcHighlightedControl.Dock = DockStyle.Fill;

            if (hcHighlightedControl != null)
            {
                hcHighlightedControl.RefreshData(true);
            }

            return true;
        }

        public bool clearHighlight(bool forced = false)
        {
            if (hcHighlightedControl != null)
            {
                if (!hcHighlightedControl.Removeable && !forced && !hcHighlightedControl.ShowRemoveMessage())
                {
                    return false;
                }

                if (HighlightedItemContainer.Controls.Contains(hcHighlightedControl))
                {
                    HighlightedItemContainer.Controls.Remove(hcHighlightedControl);
                }

                hcHighlightedControl = null;
            }

            return true;
        }

        public Panel HighlightedItemContainer
        {
            get
            {
                return pnlHighlightedItemContainer;
            }
            set
            {
                pnlHighlightedItemContainer = value;
            }
        }
    }

    public class HighlightableControl : UserControl
    {
        protected bool mRemoveable = true;

        private DateTime mLastRefresh;

        protected EditingState mCurrentEditingState;

        public bool Removeable
        {
            get
            {
                return Parent != null && mRemoveable;
            }
        }

        public void RefreshData(bool pAutoRefresh)
        {
            if (mLastRefresh == null || mLastRefresh.AddMinutes(1) < DateTime.Now || !pAutoRefresh)
            {
                mLastRefresh = DateTime.Now;
                doRefresh();
            }
        }

        protected virtual void doRefresh()
        {
            throw new NotImplementedException("doRefresh() Method must be overridden when inheriting HighlightableControl!");
        }

        protected ModelLocator modelLocator
        {
            get
            {
                return ModelLocator.getInstance();
            }
        }

        public virtual bool ShowRemoveMessage()
        {
            return false;
        }
    }

    public interface IONyRObserver<T>
    {
        void Refresh(T value);
    }

    public interface IONyRObservable<T>
    {
        void Subscribe(IONyRObserver<T> pObserver);
        void RefreshObservers();
    }
}
