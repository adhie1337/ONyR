using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System;

public enum UserFilter
{
    ById = 0, ByIds, All
};

[ServiceContract]
public interface IUserService
{
    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<UserVO> LoadUsers(UserFilter pFilter, int pId = -1, int[] pIds = null);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<UserVO> AddUsers(UserVO[] pUser);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<UserVO> RemoveUsers(UserVO[] pUser);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<UserVO> ModifyUsers(UserVO[] pOriginalUser, UserVO[] pNewUser, bool isForced = false);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    void ModifyPassword(string pOriginalPassword, string pNewPassword);
}

[DataContract]
public class UserVO
{
    [DataMember]
    public int ID;

    [DataMember]
    public string UserName;

    [DataMember]
    public string Title;

    [DataMember]
    public string FirstName;

    [DataMember]
    public string MiddleName;

    [DataMember]
    public string LastName;

    [DataMember]
    public string MothersMaidenName;

    [DataMember]
    public string EMail;

    [DataMember]
    public string IdentityCardNumber;

    [DataMember]
    public DateTime LastLogin;
    
    public UserVO()
    {
    }

    public UserVO(int pID, string pUserName, string pTitle, string pFirstName, string pMiddleName, string pLastName, string pMothersMaidenName, string pEMail, string pIdentityCardNumber, DateTime pLastLogin)
    {
        ID = pID;
        UserName = pUserName;
        Title = pTitle;
        FirstName = pFirstName;
        MiddleName = pMiddleName;
        LastName = pLastName;
        MothersMaidenName = pMothersMaidenName;
        EMail = pEMail;
        IdentityCardNumber = pIdentityCardNumber;
        LastLogin = pLastLogin;
    }

    public bool Equals(UserVO obj)
    {
        return ID == obj.ID
            && UserName == obj.UserName
            && Title == obj.Title
            && FirstName == obj.FirstName
            && MiddleName == obj.MiddleName
            && LastName == obj.LastName
            && MothersMaidenName == obj.MothersMaidenName
            && EMail == obj.EMail
            && IdentityCardNumber == obj.IdentityCardNumber
            && LastLogin == obj.LastLogin;
    }
}
