using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using ONyR_client.Services;

namespace ONyR_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtParam.Text;
            try
            {
                lblAnswer.Text = EchoService.Echo(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, String.Format("Error: {0}", ex.Message), "Error");

                lblAnswer.Text = "Error";
            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.Login(txtUserName.Text, txtPass.Text))
            {
                lblLoggedIn.Text = String.Format("Just logged in as {0}", txtUserName.Text);
                btnLogout.Enabled = true;
            }
            else
            {
                lblLoggedIn.Text = "Not logged In";
                btnLogout.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (AuthenticationService.IsLoggedIn())
            {
                AuthenticationService.Logout();
                lblLoggedIn.Text = "Logout successful!";
            }
            else
            {
                lblLoggedIn.Text = "You were already logged out! -.-";
            }

        }
    }
}
