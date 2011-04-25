using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ONyR_client.view
{
    public class HighlighterForm : Form
    {
        private HighlightableControl hcHighlightedControl;

        public bool Highlight(HighlightableControl control)
        {

            if (hcHighlightedControl != null)
            {
                if (!hcHighlightedControl.Removeable)
                {
                    return false;
                }

                if (Controls.Contains(hcHighlightedControl))
                {
                    Controls.Remove(hcHighlightedControl);
                }

                hcHighlightedControl = null;
            }

            hcHighlightedControl = control;
            Controls.Add(hcHighlightedControl);
            hcHighlightedControl.Dock = DockStyle.Fill;

            return true;
        }
    }

    public class HighlightableControl : UserControl
    {
        private bool mRemoveable = false;

        public bool Removeable
        {
            get
            {
                return Parent != null && mRemoveable;
            }
        }
    }
}
