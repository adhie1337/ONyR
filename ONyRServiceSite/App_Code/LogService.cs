using System;
using System.ServiceModel.Activation;
using ONyRDataSetTableAdapters;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class LogService : ILogService
{
    public static void Log(string pServiceName, string pOperationName, string pParams = null, string pUserName = null)
    {
        LogTableAdapter logAdapter = new LogTableAdapter();
        logAdapter.AddEntry(pServiceName, pOperationName, pParams, pUserName == null ? HttpContext.Current.User.Identity.Name : pUserName);
        logAdapter.Dispose();
    }

    public static void LogError(ErrorCode pCode, string pStackTrace=null, string pErrorMessage=null)
    {
        ErrorLogTableAdapter logAdapter = new ErrorLogTableAdapter();
        bool addedRow = false;

        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            SysUserTableAdapter adapter = new SysUserTableAdapter();
            ONyRDataSet.SysUserDataTable table = adapter.GetDataByUserName(HttpContext.Current.User.Identity.Name);
            
            if(table.Count > 0)
            {
                logAdapter.ErrorLog(table[0].ID, (int)pCode, pStackTrace, pErrorMessage);
                addedRow = true;
            }

            adapter.Dispose();
            table.Dispose();
        }
        
        if(!addedRow)
        {
            logAdapter.ErrorLog(null, (int)pCode, pStackTrace, pErrorMessage);
        }

        logAdapter.Dispose();
    }


    public List<LogVO> LoadLogEntries(int min, int max)
    {
        List<LogVO> result = null;
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            LogService.Log("LogService", "LoadLogs", String.Format("Min:{0}; Max: {1}", min, max));

            LogTableAdapter adapter = new LogTableAdapter();
            result = new List<LogVO>();

            ONyRDataSet.LogDataTable table = adapter.GetDataByRowNumber(min, max);
            for (int i = 0; i < table.Count; ++i)
            {
                DateTime date;
                try
                {
                    date = table[i].Date;
                }
                catch(Exception)
                {
                    date = DateTime.MinValue;
                }
                String sparams;
                try
                {
                    sparams = table[i].Params;
                }
                catch (Exception)
                {
                    sparams = "";
                }
                String userName;
                try
                {
                    userName = table[i].UserName;
                }
                catch (Exception)
                {
                    userName = "";
                }

                result.Add(new LogVO(table[i].ID, table[i].ServiceName, table[i].OperationName, sparams, userName, date));
            }

            adapter.Dispose();
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }

        return result;
    }

    public List<ErrorLogVO> LoadErrorLogEntries(int min, int max)
    {
        List<ErrorLogVO> result = null;
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            LogService.Log("LogService", "LoadErrorLogs", String.Format("Min:{0}; Max: {1}", min, max));

            ErrorLogTableAdapter adapter = new ErrorLogTableAdapter();
            result = new List<ErrorLogVO>();

            ONyRDataSet.ErrorLogDataTable table = adapter.GetDataByRowNumber(min, max);
            for (int i = 0; i < table.Count; ++i)
            {
                DateTime date;
                try
                {
                    date = table[i].Date;
                }
                catch (Exception)
                {
                    date = DateTime.MinValue;
                }
                int userID;
                try
                {
                    userID = table[i].UserID;
                }
                catch (Exception)
                {
                    userID = -1;
                }
                String errorMessage;
                try
                {
                    errorMessage = table[i].ErrorMessage;
                }
                catch (Exception)
                {
                    errorMessage = "";
                }
                String stacktrace;
                try
                {
                    stacktrace = table[i].StackTrace;
                }
                catch (Exception)
                {
                    stacktrace = "";
                }
                result.Add(new ErrorLogVO(table[i].ID, date, userID, table[i].ErrorCode, errorMessage, stacktrace));
            }

            adapter.Dispose();
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }

        return result;
    }
}