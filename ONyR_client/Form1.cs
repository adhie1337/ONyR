using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ONyR_client.EchoService;
using ONyR_client.AuthenticationService;

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
            int i = -1;

            try
            {
                i = Convert.ToInt32(txtParam.Text);
            }
            catch (Exception)
            {
                lblAnswer.Text = "Rendes számot kérek!";
            }

            EchoServiceClient client = new EchoServiceClient();

            lblAnswer.Text = client.Echo(i.ToString());

            client.Close();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            AuthenticationServiceClient authClient = new AuthenticationServiceClient();
            
            if (authClient.Login(txtUserName.Text, txtPass.Text, "", false))
            {
                lblLoggedIn.Text = "Just logged In";
                btnLogout.Enabled = true;
            }
            else
            {
                lblLoggedIn.Text = "Not logged In";
                btnLogout.Enabled = false;
            }

            authClient.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthenticationServiceClient authClient = new AuthenticationServiceClient();

            if (authClient.IsLoggedIn())
            {
                authClient.Logout();
                authClient.Close();
                lblLoggedIn.Text = "Not logged In";
                btnLogout.Enabled = false;
            }
            else
            {
                authClient.Close();
                throw new Exception("Nem is vagy loginolva baze!");
            }

        }
    }
}
