using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using ONyRDataSetTableAdapters;
using System.Security.Cryptography;
using System.Text;

public class AuthenticationService
{
    private static string hashPassword(string pass)
    {
        SHA256CryptoServiceProvider hash = new SHA256CryptoServiceProvider();

        byte[] a = hash.ComputeHash(Encoding.UTF8.GetBytes(pass + "_ONyR_salt"));

        StringBuilder sb = new StringBuilder(a.Length * 2);
        foreach (byte b in a)
        {
            sb.AppendFormat("{0:X2}", b);
        }

        return sb.ToString();
    }

    public static bool authenticate(string userName, string password)
    {
        bool result = false;
        string encodedPass = hashPassword(password);

        SysUserTableAdapter userAdapter = new SysUserTableAdapter();
        result = (int)userAdapter.CheckUser(userName, encodedPass) != 0;
        userAdapter.Dispose();

        LogService.Log("AuthenticationService", "authenticate", String.Format("username:{0}; result:{1}", userName, result));

        return result;
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

        if(users.Count == 0)
        {
            throw new ONyRException(ErrorCode.InvalidCredentialsError);
        }

        ONyRDataSet.SysUserRow user = users[0];

        SysSessionTableAdapter sessionAdapter = new SysSessionTableAdapter();
        sessions = sessionAdapter.GetDataByUserID(user.ID);

        foreach(ONyRDataSet.SysSessionRow row in sessions)
        {
            sessionAdapter.Delete1(row.ID);
        }

        sessionAdapter.CreateSession(user.ID);
        sessions = sessionAdapter.GetDataByUserID(user.ID);
        session = sessions[0];
        sessionAdapter.Dispose();

        userAdapter.UpdateLoginDate(user.ID);
        userAdapter.Dispose();

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
        sessions = sessionAdapter.GetDataByUserID(Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value));

        foreach (ONyRDataSet.SysSessionRow row in sessions)
        {
            if (row.SessionModified.AddMinutes(30).CompareTo(DateTime.Now) > 0)
            {
                validSession = true;
            }
            else
            {
                sessionAdapter.Delete1(row.ID);
            }
        }

        if (!validSession)
        {
            throw new ONyRException(ErrorCode.InvalidSessionError);
        }
    }

    public static void ChangePassword(string pOldPassword, string pNewPassword)
    {
        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);

        SysUserTableAdapter adapter = new SysUserTableAdapter();
        int i = adapter.ModifyPassword(pNewPassword, pOldPassword, userID);

        if (i == 0)
        {
            throw new ONyRException(ErrorCode.InvalidCredentialsError);
        }
    }
}