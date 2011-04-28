using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using ONyRDataSetTableAdapters;

public class AuthenticationService
{
    public static bool authenticate(string userName, string passWord)
    {
        bool retVal = false;

        SysUserTableAdapter userAdapter = new SysUserTableAdapter();
        retVal = userAdapter.CheckUser(userName, passWord) != 0;
        userAdapter.Dispose();

        LogService.Log("AuthenticationService", "authenticate", String.Format("username:{0}; result:{1}", userName, retVal));

        return retVal;
    }

    public static void Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        e.Authenticated = AuthenticationService.authenticate(e.UserName, e.Password);
        e.AuthenticationIsComplete = true;
    }

    public static void CreationCookie(object sender, System.Web.ApplicationServices.CreatingCookieEventArgs e)
    {
        ONyRDataSet.SysUserDataTable users;
        ONyRDataSet.SysSessionDataTable sessions;
        ONyRDataSet.SysSessionRow session;

        SysUserTableAdapter userAdapter = new SysUserTableAdapter();
        users = userAdapter.GetDataByUserName(e.UserName);
        userAdapter.Dispose();

        if(users.Count == 0)
        {
            throw new ONyRException(ErrorCode.InvalidCredentialsError);
        }

        ONyRDataSet.SysUserRow user = users[0];


        SysSessionTableAdapter sessionAdapter = new SysSessionTableAdapter();
        sessions = sessionAdapter.GetDataByUserID(user.ID);

        foreach(ONyRDataSet.SysSessionRow row in sessions)
        {
            sessionAdapter.Delete(row.ID);
        }

        sessionAdapter.CreateSession(user.ID);
        sessions = sessionAdapter.GetDataByUserID(user.ID);
        session = sessions[0];
        sessionAdapter.Dispose();

        HttpContext.Current.Response.Cookies.Add(new HttpCookie("UserId", user.ID.ToString()));
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("SessionId", session.ID.ToString()));
    }

    public static void CheckIfUSerIsAuthenticated()
    {
        ONyRDataSet.SysSessionDataTable sessions;

        if (HttpContext.Current.User.Identity.IsAuthenticated == false)
        {
            throw new ONyRException(ErrorCode.NoSessionError);
        }

        bool validSession = false;
        SysSessionTableAdapter sessionAdapter = new SysSessionTableAdapter();
        sessions = sessionAdapter.GetDataByUserID(Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"]));

        foreach (ONyRDataSet.SysSessionRow row in sessions)
        {
            if (row.SessionModified.AddMinutes(30).CompareTo(DateTime.Now) > 0)
            {
                validSession = true;
            }
            else
            {
                sessionAdapter.Delete(row.ID);
            }
        }

        if (!validSession)
        {
            throw new ONyRException(ErrorCode.InvalidSessionError);
        }
    }
}