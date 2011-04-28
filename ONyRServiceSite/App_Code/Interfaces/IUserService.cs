using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

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
    void AddUsers(UserVO[] pUsers);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    void RemoveUsers(UserVO[] pUsers);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    void ModifyUsers(UserVO[] pOriginalUsers, UserVO[] pNewUsers, bool isForced = false);
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

[DataContract]
public partial class ONyRFaultException : object, System.Runtime.Serialization.IExtensibleDataObject
{
    private int mErrorCode;
    private ExtensionDataObject mExtensionDataObject;

    public ONyRFaultException(ErrorCode pErrorCode)
    {
        mErrorCode = (int)pErrorCode;
    }

    [DataMember]
    public int ErrorCode
    {
        get
        {
            return mErrorCode;
        }
        set
        {
            mErrorCode = value;
        }
    }

    public ExtensionDataObject ExtensionData
    {
        get
        {
            return mExtensionDataObject;
        }
        set
        {
            mExtensionDataObject = value;
        }
    }
}