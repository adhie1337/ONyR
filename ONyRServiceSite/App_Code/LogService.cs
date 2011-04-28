using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONyRDataSetTableAdapters;

/// <summary>
/// Summary description for LogService
/// </summary>
public class LogService
{
    public static void Log(string pServiceName, string pOperationName, string pParams = null, string pUserName = null)
    {
        LogTableAdapter logAdapter = new LogTableAdapter();
        logAdapter.AddEntry(pServiceName, pOperationName, pParams, pUserName == null ? HttpContext.Current.User.Identity.Name : pUserName);
        logAdapter.Dispose();
    }

    public static void LogError(ErrorCode pCode, string pStackTrace=null)
    {
        ErrorLogTableAdapter logAdapter = new ErrorLogTableAdapter();
        bool addedRow = false;

        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            SysUserTableAdapter adapter = new SysUserTableAdapter();
            ONyRDataSet.SysUserDataTable table = adapter.GetDataByUserName(HttpContext.Current.User.Identity.Name);
            
            if(table.Count > 0)
            {
                logAdapter.ErrorLog(table[0].ID, (int)pCode, pStackTrace);
                addedRow = true;
            }

            adapter.Dispose();
            table.Dispose();
        }
        
        if(!addedRow)
        {
            logAdapter.ErrorLog(null, (int)pCode, pStackTrace);
        }

        logAdapter.Dispose();
    }
}