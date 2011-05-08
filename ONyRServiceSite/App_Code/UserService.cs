using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ONyRDataSetTableAdapters;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class UserService : IUserService
{
    private string hashPassword(string pass)
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

    public List<UserVO> LoadUsers(UserFilter pFilter, int pId = -1, int[] pIds = null)
    {
        List<UserVO> result = null;
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            LogService.Log("UserService", "LoadUser", String.Format("Filter:{0}; ID:{1}; IDs: {2}", pFilter, pId, pIds));

            SysUserTableAdapter adapter = new SysUserTableAdapter();
            ONyRDataSet.SysUserDataTable table;
            result = new List<UserVO>();


            if (pFilter == UserFilter.All)
            {
                table = adapter.GetData();

            }
            else if (pFilter == UserFilter.ById)
            {
                table = adapter.GetDataByID(pId);
            }
            else if (pFilter == UserFilter.ByIds)
            {
                table = adapter.GetData();
            }
            else
            {
                throw new ONyRException(ErrorCode.UnknownError);
            }

            for (int i = 0; i < table.Count; ++i)
            {
                if (pFilter != UserFilter.ByIds || pIds.Contains(table[i].ID))
                {
                    string title = table[i].IsTitleNull() ? "" : table[i].Title;
                    string middleName = table[i].IsMiddleNameNull() ? "" : table[i].MiddleName;
                    string mothersMaindenName = table[i].IsMothersMaindenNameNull() ? "" : table[i].MothersMaindenName;
                    DateTime lastLogin = table[i].IsLastLoginNull() ? DateTime.MinValue : table[i].LastLogin;

                    result.Add(
                        new UserVO(
                            table[i].ID,
                            table[i].UserName,
                            title,
                            table[i].FirstName,
                            middleName,
                            table[i].LastName,
                            mothersMaindenName,
                            table[i].Email,
                            table[i].IdentityCardNumber,
                            lastLogin
                            )
                        );
                }
            }

            adapter.Dispose();
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (SqlException ex)
        {
            string s = "Class: " + ex.Class + "\n";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                s += "Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Class: " + ex.Errors[i].Class + "\n";
            }
            LogService.LogError(ErrorCode.UnknownError, null, s);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.DatabaseError));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }


        return result;
    }

    public List<UserVO> AddUsers(UserVO[] pUser)
    {
        List<UserVO> result = new List<UserVO>();
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            SysUserTableAdapter adapter = new SysUserTableAdapter();
            string logParams = "";

            foreach (UserVO vo in pUser)
            {
                if (logParams.Length > 0)
                {
                    logParams += ",\n";
                }

                vo.ID = (int)adapter.SmartInsert(1, vo.UserName, hashPassword("ONyR"), vo.Title, vo.FirstName, vo.MiddleName, vo.LastName, vo.MothersMaidenName, vo.EMail, vo.IdentityCardNumber);
                result.Add(vo);

                logParams += String.Format("UserName: \"{0}\", Title: \"{1}\", FirstName: \"{2}\", MiddleName: \"{3}\", LastName: \"{4}\", MothersMaidenName: \"{5}\", EMail: \"{6}\", IdentityCardNumber: \"{7\"", vo.UserName, vo.Title, vo.FirstName, vo.MiddleName, vo.LastName, vo.MothersMaidenName, vo.EMail, vo.IdentityCardNumber, vo.LastLogin);
            }

            adapter.Dispose();

            LogService.Log("UserService", "AddUser", logParams);
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode,  e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (SqlException ex)
        {
            string s = "Class: " + ex.Class + "\n";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                s += "Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Class: " + ex.Errors[i].Class + "\n";
            }
            LogService.LogError(ErrorCode.UnknownError, null, s);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.DatabaseError));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }

        return result;
    }

    public List<UserVO> RemoveUsers(UserVO[] pUser)
    {
        List<UserVO> result = new List<UserVO>();
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            SysUserTableAdapter adapter = new SysUserTableAdapter();
            string logParams = "";

            foreach (UserVO vo in pUser)
            {
                if (logParams.Length > 0)
                {
                    logParams += ",\n";
                }

                adapter.Delete(vo.ID);
                result.Add(vo);

                logParams += String.Format("UserName: \"{0}\", Title: \"{1}\", FirstName: \"{2}\", MiddleName: \"{3}\", LastName: \"{4}\", MothersMaidenName: \"{5}\", EMail: \"{6}\", IdentityCardNumber: \"{7\", LastLogin: \"{8}\", ID: {9}", vo.UserName, vo.Title, vo.FirstName, vo.MiddleName, vo.LastName, vo.MothersMaidenName, vo.EMail, vo.IdentityCardNumber, vo.LastLogin, vo.ID);
            }

            adapter.Dispose();

            LogService.Log("UserService", "RemoveUser", logParams);
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (SqlException ex)
        {
            if (ex.Class == 16)
            {
                LogService.LogError(ErrorCode.ReferenceError, ex.StackTrace);
                throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.ReferenceError));
            }
            string s = "Class: " + ex.Class + "\n";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                s += "Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Class: " + ex.Errors[i].Class + "\n";
            }
            LogService.LogError(ErrorCode.UnknownError, null, s);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.DatabaseError));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }

        return result;
    }

    public List<UserVO> ModifyUsers(UserVO[] pOriginalUser, UserVO[] pNewUser, bool isForced = false)
    {
        List<UserVO> result = new List<UserVO>();
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            SysUserTableAdapter adapter = new SysUserTableAdapter();
            string logParams = "";
            bool modifyConflict = false;

            for (int i = 0; i < Math.Min(pOriginalUser.Length, pNewUser.Length); ++i)
            {
                ONyRDataSet.SysUserRow row = adapter.GetDataByID(pNewUser[i].ID)[0];

                string title = row.IsTitleNull() ? "" : row.Title;
                string middleName = row.IsMiddleNameNull() ? "" : row.MiddleName;
                string mothersMaindenName = row.IsMothersMaindenNameNull() ? "" : row.MothersMaindenName;
                DateTime lastLogin = row.IsLastLoginNull() ? DateTime.MinValue : row.LastLogin;

                UserVO vo = new UserVO(row.ID, row.UserName, title, row.FirstName, middleName, row.LastName, mothersMaindenName, row.Email, row.IdentityCardNumber, lastLogin);

                if (vo.Equals(pOriginalUser[i]) || isForced)
                {
                    if (logParams.Length > 0)
                    {
                        logParams += ",\n";
                    }
                    adapter.UpdateUser(pNewUser[i].UserName, pNewUser[i].Title, pNewUser[i].FirstName, pNewUser[i].MiddleName, pNewUser[i].LastName, pNewUser[i].MothersMaidenName, pNewUser[i].EMail, pNewUser[i].IdentityCardNumber, vo.ID);
                    logParams += String.Format("ID: \"{0}\" => \"{1}\", UserName: \"{2}\" => \"{3}\", Title: \"{4}\" => \"{5}\", FirstName: \"{6}\" => \"{7}\", MiddleName: \"{8}\" => \"{9}\", LastName: \"{10}\" => \"{11}\", MothersMaidenName: \"{12}\" => \"{13}\", EMail: \"{14}\" => \"{15}\", IdentityCardNumber: \"{16}\" => \"{17}\", LastLogin: \"{18}\" => \"{19}\"", vo.ID, pNewUser[i].ID, vo.UserName, pNewUser[i].UserName, vo.Title, pNewUser[i].Title, vo.FirstName, pNewUser[i].FirstName, vo.MiddleName, pNewUser[i].MiddleName, vo.LastName, pNewUser[i].LastName, vo.MothersMaidenName, pNewUser[i].MothersMaidenName, vo.EMail, pNewUser[i].EMail, vo.IdentityCardNumber, pNewUser[i].IdentityCardNumber, vo.LastLogin, pNewUser[i].LastLogin);

                    result.Add(new UserVO(vo.ID, pNewUser[i].UserName, pNewUser[i].Title, pNewUser[i].FirstName, pNewUser[i].MiddleName, pNewUser[i].LastName, pNewUser[i].MothersMaidenName, pNewUser[i].EMail, pNewUser[i].IdentityCardNumber, lastLogin));
                }
                else
                {
                    modifyConflict = true;
                }
            }

            adapter.Dispose();

            LogService.Log("UserService", "ModifyUser", logParams);
			
            if (modifyConflict)
            {
                throw new ONyRException(ErrorCode.ModifyConflict);
            }
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (SqlException ex)
        {
            string s = "Class: " + ex.Class + "\n";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                s += "Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Class: " + ex.Errors[i].Class + "\n";
            }
            LogService.LogError(ErrorCode.UnknownError, null, s);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.DatabaseError));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }

        return result;
    }

    public void ModifyPassword(string pOriginalPassword, string pNewPassword)
    { 
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            AuthenticationService.ChangePassword(hashPassword(pOriginalPassword), hashPassword(pNewPassword));
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)e.ErrorCode));
        }
        catch (SqlException ex)
        {
            string s = "Class: " + ex.Class + "\n";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                s += "Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Class: " + ex.Errors[i].Class + "\n";
            }
            LogService.LogError(ErrorCode.DatabaseError, null, s);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.DatabaseError));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace, e.Message);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException((int)ErrorCode.UnknownError));
        }

    }
}
