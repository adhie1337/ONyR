using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONyR_server.ONyRDataSetTableAdapters;

namespace ONyR_server
{
    public class AuthenticationService
    {
        public static bool authenticate(string userName, string passWord)
        {
            ActivityLogTableAdapter adapter = new ActivityLogTableAdapter();
            adapter.InsertOne("AuthenticationService", "authenticate", null);
            adapter.Dispose();

            SysUserTableAdapter userAdapter = new SysUserTableAdapter();
            Object retVal = userAdapter.CheckCredentials(userName, passWord);
            userAdapter.Dispose();

            return (int)retVal == 1;
        }
    }
}