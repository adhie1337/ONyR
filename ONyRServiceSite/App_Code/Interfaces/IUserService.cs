using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

public enum UserFilter
{
    ById = 0, ByIds, All
};

[ServiceContract]
public interface IUserService
{
    [OperationContract]
    List<UserVO> LoadUsers(UserFilter pFilter, int pId = -1, int[] pIds = null);
}

[DataContract]
public class UserVO
{
    [DataMember]
    public int ID;

    [DataMember]
    public string UserName;

    [DataMember]
    public string Name;

    public UserVO(int pId, string pUserName, string pName)
    {
        ID = pId;
        UserName = pUserName;
        Name = pName;
    }
}