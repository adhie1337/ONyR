using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Net;
using System.Web;
using System.Web.ApplicationServices;
using ONyRDataSetTableAdapters;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class UserService : IUserService
{
    public List<UserVO> LoadUsers(UserFilter pFilter, int pId = -1, int[] pIds = null)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated == false)
        {
            throw new Exception("Authentication needed to use this method");
        }

        LogTableAdapter logAdapter = new LogTableAdapter();
        logAdapter.AddEntry("UserService", "LoadUsers", String.Format("Filter:{0}; ID:{1}; IDs: {2}", pFilter, pId, pIds), HttpContext.Current.User.Identity.Name);
        logAdapter.Dispose();

        SysUserTableAdapter adapter = new SysUserTableAdapter();
        ONyRDataSet.SysUserDataTable table;
        List<UserVO> retVal = new List<UserVO>();
        

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
            throw new NotImplementedException("Illegal use of UserService!");
        }

        for (int i = 0; i < table.Count; ++i)
        {
            retVal.Add(new UserVO(table[i].ID, table[i].UserName, table[i].Name));
        }

        return retVal;
	}
}
