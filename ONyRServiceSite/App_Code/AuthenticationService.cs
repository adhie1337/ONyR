using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

public class AuthenticationService
{
    public static bool authenticate(string userName, string passWord)
    {
        bool retVal = false;

        // Check user's credentials
        ONyRDataSetTableAdapters.SysUserTableAdapter userAdapter = new ONyRDataSetTableAdapters.SysUserTableAdapter();
        retVal = userAdapter.CheckUser(userName, passWord) != 0;
        userAdapter.Dispose();

        // Log mechanism
        ONyRDataSetTableAdapters.LogTableAdapter logAdapter = new ONyRDataSetTableAdapters.LogTableAdapter();
        logAdapter.Insert("AuthenticationService", "authenticate", String.Format("username:{0}; result:{1}", userName, retVal), userName);
        logAdapter.Dispose();

        return retVal;
    }

    public static void Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        e.Authenticated = AuthenticationService.authenticate(e.UserName, e.Password);
        e.AuthenticationIsComplete = true;
    }

}