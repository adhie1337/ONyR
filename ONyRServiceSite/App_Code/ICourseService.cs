using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

public enum CourseFilter
{
    ById = 0, ByIds, All, ByUserID
};

[ServiceContract]
public interface ICourseService
{
    [OperationContract]
    List<CourseVO> LoadCourses(CourseFilter pFilter, int pId = -1, int[] pIds = null);
}

[DataContract]
public class CourseVO
{
    [DataMember]
    public int ID;

    [DataMember]
    public string Name;

    public CourseVO(int pId, string , string pName)
    {
        ID = pId;
        Name = pName;
    }
}