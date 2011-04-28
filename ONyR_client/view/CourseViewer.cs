using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ONyR_client.control.notifiers.User;

namespace ONyR_client.view
{
    public partial class CourseViewer : HighlightableControl
    {
        public CourseViewer()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            new LoadUsersNotifier(LoadUsersNotifier.UserFilter.All).Handle();
        }
    }
}
