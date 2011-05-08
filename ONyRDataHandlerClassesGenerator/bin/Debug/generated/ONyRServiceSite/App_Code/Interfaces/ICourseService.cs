using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

public enum CourseFilter
{
    ById = 0, ByIds, All
};

[ServiceContract]
public interface ICourseService
{
    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<CourseVO> LoadCourses(CourseFilter pFilter, int pId = -1, int[] pIds = null);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<CourseVO> AddCourses(CourseVO[] pCourses);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<CourseVO> RemoveCourses(CourseVO[] pCourses);

    [OperationContract]
    [FaultContractAttribute(typeof(ONyRFaultException))]
    List<CourseVO> ModifyCourses(CourseVO[] pOriginalCourses, CourseVO[] pNewCourses, bool isForced = false);
}

[DataContract]
public class CourseVO
{
    [DataMember]
    public int ID;

	// TODO: Fill the properties
    /*
	[DataMember]
    public string Name;
	*/
    
    public CourseVO()
    {
    }

    public CourseVO(int pID/*, string pName*/)
    {
        ID = pID;
        /*
		Name = pName;
		*/
    }

    public bool Equals(CourseVO obj)
    {
        return ID == obj.ID
			/*
            && Name == obj.Name
			*/
			;
    }
}
