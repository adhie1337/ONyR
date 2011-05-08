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
using ONyR_client.control;
using ONyR_client.utils;

namespace ONyR_client.view
{
    public partial class MainForm : HighlighterForm, IONyRObserver<ApplicationState>
    {
        #region Members

        private LoginForm lfLogin;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            pnlHighlightedItemContainer = pnlOwnHighlightedItemContainer;

            ModelLocator.getInstance().SessionModel.UpdateEvent += new Model.UpdateHandler(SessionModel_UpdateEvent);
            ModelLocator.getInstance().SessionModel.Subscribe(this);

            new LoginUserNotifier("adhie", "passbaze").Handle();
        }

        #endregion

        #region Event handlers

        void SessionModel_UpdateEvent(object pSender, EventArgs e)
        {
            RefreshData();
        }

        private void miLogin_Click(object sender, EventArgs e)
        {
            showLoginForm();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            new LogoutUserNotifier().Handle();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiAdminUsers_Click(object sender, EventArgs e)
        {
            Highlight(new UserEditor());
        }

        private void tsmiAdminUniversities_Click(object sender, EventArgs e)
        {
            Highlight(new ProgrammeEditor());
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            RefreshData(false);
        }
        
        private void tsmiLogging_Click(object sender, EventArgs e)
        {
            Highlight(new LogViewer());
        }


        private void tsmiOptions_Click(object sender, EventArgs e)
        {
            new UserEditorForm(ModelLocator.getInstance().SessionModel.CurrentUser).ShowDialog();
        }

        #endregion

        #region Misc functions

        public void showLoginForm()
        {
            if (lfLogin == null)
            {
                lfLogin = new LoginForm();
            }

            lfLogin.ShowDialog();
        }

        public void RefreshData(bool pAutoRefresh = true)
        {
            if (hcHighlightedControl != null)
            {
                hcHighlightedControl.RefreshData(pAutoRefresh);
            }
        }

        #endregion

        #region IObserver<ApplicationState> Members

        public void Refresh(ApplicationState value)
        {
            switch (value)
            {
                case ApplicationState.Loading:
                    lblConnectionState.Text = "Betöltés...";
                    miLogin.Enabled = true;
                    miLogout.Enabled = false;
                    tsmiOptions.Enabled = false;
                    tspbLoader.Visible = true;
                    break;
                case ApplicationState.Offline:
                    lblConnectionState.Text = "Nincs kapcsolat.";
                    miLogin.Enabled = true;
                    miLogout.Enabled = false;
                    tsmiOptions.Enabled = false;
                    tspbLoader.Visible = false;
                    break;
                case ApplicationState.Anonimous:
                case ApplicationState.Online:
                    lblConnectionState.Text = value == ApplicationState.Online ? String.Format(
                        "Bejelentkezve mint: {0}.",
                        UserNameFormatter.Format(ModelLocator.getInstance().SessionModel.CurrentUser)
                       ) : "Bejelentkezve.";
                    miLogin.Enabled = false;
                    miLogout.Enabled = true;
                    tsmiOptions.Enabled = value == ApplicationState.Online;
                    tspbLoader.Visible = false;

                    if (lfLogin != null)
                    {
                        lfLogin.Close();
                        lfLogin = null;
                    }
                    break;
            }
        }

        #endregion

    }
}
