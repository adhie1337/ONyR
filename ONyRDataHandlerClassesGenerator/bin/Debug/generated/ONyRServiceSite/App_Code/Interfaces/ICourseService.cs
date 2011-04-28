using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System;

public enum CourseFilter
{
    ById = 0, ByIds, All
};

[ServiceContract]
public interface ICourseService
{
    [OperationContract]
    List<CourseVO> LoadCourses(CourseFilter pFilter, int pId = -1, int[] pIds = null);

    [OperationContract]
    void AddCourses(CourseVO[] pCourses);

    [OperationContract]
    void RemoveCourses(CourseVO[] pCourses);

    [OperationContract]
    void ModifyCourses(CourseVO[] pOriginalCourses, CourseVO[] pNewCourses, bool isForced = false);
}

[DataContract]
public class CourseVO
{
    [DataMember]
    public int ID;

    [DataMember]
    public string CourseName;

    [DataMember]
    public string Name;

    public CourseVO(int pId, string pCourseName, string pName)
    {
        ID = pId;
        CourseName = pCourseName;
        Name = pName;
    }
}
