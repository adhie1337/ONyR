using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ONyR_client.view;
using ONyR_client.control;

namespace ONyR_client
{
    public enum ApplicationState
    {
        Offline, Anonimous, Online, Loading
    }

    class ONyRClientApplication
    {

        private static MainForm mfMain;

        private List<FrontController> controllers;

        public ONyRClientApplication()
        {
            InitializeControllers();
        }

        private void InitializeControllers()
        {
            controllers = new List<FrontController>();

            controllers.Add(new SessionController());
            controllers.Add(new ExamController());
            controllers.Add(new FacultyController());
            controllers.Add(new PostController());
            controllers.Add(new ProgrammeController());
            controllers.Add(new UniversityController());
            controllers.Add(new UserController());
            controllers.Add(new SemesterController());
            controllers.Add(new LogController());
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mfMain = new MainForm();
            try
            {
                Application.Run(mfMain);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void RefreshData()
        {
            if (mfMain != null)
            {
                mfMain.RefreshData();
            }
        }

        public static void ShowLoginForm()
        {
            if (mfMain != null)
            {
                mfMain.showLoginForm();
            }
        }
    }
}
