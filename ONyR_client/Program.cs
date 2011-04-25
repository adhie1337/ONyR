using System;
using System.Collections.Generic;
using System.Linq;

namespace ONyR_client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new ONyRClientApplication().Run();
        }
    }
}
