using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            Service1Reference.Service1Client client = new Service1Reference.Service1Client();

            lblAnswer.Text = client.GetData(i);

            client.Close();
        }
    }
}
