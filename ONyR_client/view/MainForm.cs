using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ONyR_client.model;
using ONyR_client.model.models;
using ONyR_client.control.notifiers.Session;

namespace ONyR_client.view
{
    public partial class MainForm : HighlighterForm
    {
        private LoginForm lfLogin;

        public MainForm()
        {
            InitializeComponent();

            ModelLocator.getInstance().SessionModel.UpdateEvent += new Model.UpdateHandler(SessionModel_UpdateEvent);
            ModelLocator.getInstance().UserModel.UpdateEvent += new Model.UpdateHandler(UserModel_UpdateEvent);
        }

        #region Event handlers

        void UserModel_UpdateEvent(object pSender, EventArgs e)
        {
        }

        void SessionModel_UpdateEvent(object pSender, EventArgs e)
        {
            refreshConnectionLabel();
        }

        private void miLogin_Click(object sender, EventArgs e)
        {
            if (lfLogin == null)
            {
                lfLogin = new LoginForm();
            }

            lfLogin.ShowDialog();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            new LogoutUserNotifier().Handle();
        }

        private void miShowCourses_Click(object sender, EventArgs e)
        {
            Highlight(new CourseViewer());
        }

        #endregion

        #region misc functions

        private void refreshConnectionLabel()
        {
            SessionModel model = ModelLocator.getInstance().SessionModel;

            if (model.IsLoggedIn)
            {
                lblConnectionState.Text = model.CurrentUser != null ? String.Format("Bejelentkezve mint: {0}.", model.CurrentUser.Name) : "Bejelentkezve.";
                miLogin.Enabled = false;
                miLogout.Enabled = true;

                if (lfLogin != null)
                {
                    lfLogin.Close();
                    lfLogin = null;
                }
            }
            else
            {
                lblConnectionState.Text = "Nincs kapcsolat.";
                miLogin.Enabled = true;
                miLogout.Enabled = false;
            }
        }

        #endregion

    }
}
