using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using ONyRDataSetTableAdapters;
using System.ServiceModel;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class UserService : IUserService
{
    public List<UserVO> LoadUsers(UserFilter pFilter, int pId = -1, int[] pIds = null)
    {
        List<UserVO> retVal = null;
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            LogService.Log("UserService", "LoadUsers", String.Format("Filter:{0}; ID:{1}; IDs: {2}", pFilter, pId, pIds));

            SysUserTableAdapter adapter = new SysUserTableAdapter();
            ONyRDataSet.SysUserDataTable table;
            retVal = new List<UserVO>();


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
                    retVal.Add(new UserVO(table[i].ID, table[i].UserName, table[i].Name));
                }
            }

            adapter.Dispose();
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(e.ErrorCode));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(ErrorCode.UnknownError));
        }


        return retVal;
	}

    public void AddUsers(UserVO[] pUsers)
    {
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            SysUserTableAdapter adapter = new SysUserTableAdapter();

            foreach (UserVO vo in pUsers)
            {
                adapter.Insert(vo.UserName, vo.Name);
            }

            adapter.Dispose();

            LogService.Log("UserService", "AddUsers");
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(e.ErrorCode));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(ErrorCode.UnknownError));
        }
    }

    public void RemoveUsers(UserVO[] pUsers)
    {
        try{
            AuthenticationService.CheckIfUSerIsAuthenticated();
            SysUserTableAdapter adapter = new SysUserTableAdapter();

            foreach (UserVO vo in pUsers)
            {
                adapter.Delete(vo.ID);
            }

            adapter.Dispose();

            LogService.Log("UserService", "AddUsers");
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(e.ErrorCode));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(ErrorCode.UnknownError));
        }
    }

    public void ModifyUsers(UserVO[] pOriginalUsers, UserVO[] pNewUsers, bool isForced=false)
    {
        try{
            AuthenticationService.CheckIfUSerIsAuthenticated();
            SysUserTableAdapter adapter = new SysUserTableAdapter();

            for (int i = 0; i < Math.Min(pOriginalUsers.Length, pNewUsers.Length); ++i)
            {
                ONyRDataSet.SysUserRow row = adapter.GetDataByID(pNewUsers[i].ID)[0];
                UserVO vo = new UserVO(row.ID, row.UserName, row.Name);

                if (vo.Equals(pOriginalUsers[i]) || isForced)
                {
                    adapter.Update(pNewUsers[i].UserName, pNewUsers[i].Name, pNewUsers[i].ID);
                }
                else
                {
                    throw new ONyRException(ErrorCode.ModifyConflict);
                }
            }

            adapter.Dispose();

            LogService.Log("UserService", "ModifyUsers");
        }
        catch (ONyRException e)
        {
            LogService.LogError(e.ErrorCode, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(e.ErrorCode));
        }
        catch (Exception e)
        {
            LogService.LogError(ErrorCode.UnknownError, e.StackTrace);
            throw new FaultException<ONyRFaultException>(new ONyRFaultException(ErrorCode.UnknownError));
        }
    }

}
