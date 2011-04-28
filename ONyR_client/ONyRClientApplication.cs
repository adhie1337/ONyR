using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ONyR_client.view;
using ONyR_client.control;

namespace ONyR_client
{
    class ONyRClientApplication
    {
        private List<FrontController> controllers;

        public ONyRClientApplication()
        {
            InitializeControllers();
        }

        private void InitializeControllers()
        {
            controllers = new List<FrontController>();

            controllers.Add(new SessionController());
            controllers.Add(new UserController());
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
