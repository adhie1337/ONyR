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

        private void button1_Click(object sender, EventArgs e)
        {
            int i = -1;
            try
            {
                i = Convert.ToInt32(txtParam.Text);
            }
            catch (Exception)
            {
                lblAnswer.Text = "Gimme a valid number!";
                return;
            }


            TestServiceReference.TestServiceClient client = new TestServiceReference.TestServiceClient();

            lblAnswer.Text = "Your question: " + i + "\n The answer: " + client.DoWork(i);

            client.Close();
        }
    }
}
