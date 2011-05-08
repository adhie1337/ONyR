using System;
using System.Windows.Forms;
using ONyR_client.control.notifiers.Session;

namespace ONyR_client.view
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new LoginUserNotifier(txtUserName.Text, txtPassword.Text).Handle();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            (Parent as MainForm).clearHighlight();
            Close();
        }
    }
}
