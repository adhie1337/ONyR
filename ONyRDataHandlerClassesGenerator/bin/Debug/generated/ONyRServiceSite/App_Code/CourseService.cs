using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using ONyRDataSetTableAdapters;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class CourseService : ICourseService
{
    public List<CourseVO> LoadCourses(CourseFilter pFilter, int pId = -1, int[] pIds = null)
    {
        AuthenticationService.CheckIfUSerIsAuthenticated();
        LogService.Log("CourseService", "LoadCourses", String.Format("Filter:{0}; ID:{1}; IDs: {2}", pFilter, pId, pIds));

        CourseTableAdapter adapter = new CourseTableAdapter();
        ONyRDataSet.CourseDataTable table;
        List<CourseVO> retVal = new List<CourseVO>();
        

        if (pFilter == CourseFilter.All)
        {
            table = adapter.GetData();

        }
        else if (pFilter == CourseFilter.ById)
        {
            table = adapter.GetDataByID(pId);
        }
        else if (pFilter == CourseFilter.ByIds)
        {
            table = adapter.GetData();
        }
        else
        {
            LogService.LogError(LogService.ErrorCode.UnknownError);
            throw new Exception(((int)LogService.ErrorCode.UnknownError).ToString());
        }

        for (int i = 0; i < table.Count; ++i)
        {
            if (pFilter != CourseFilter.ByIds || pIds.Contains(table[i].ID))
            {
                retVal.Add(new CourseVO(table[i].ID, table[i].CourseName, table[i].Name));
            }
        }

        adapter.Dispose();

        return retVal;
	}

    public void AddCourses(CourseVO[] pCourses)
    {
        AuthenticationService.CheckIfUSerIsAuthenticated();
        CourseTableAdapter adapter = new CourseTableAdapter();
        
        foreach (CourseVO vo in pCourses)
        {
            adapter.Insert(vo.CourseName, vo.Name);
        }

        adapter.Dispose();

        LogService.Log("CourseService", "AddCourses");
    }

    public void RemoveCourses(CourseVO[] pCourses)
    {
        AuthenticationService.CheckIfUSerIsAuthenticated();
        CourseTableAdapter adapter = new CourseTableAdapter();

        foreach (CourseVO vo in pCourses)
        {
            adapter.Delete(vo.ID);
        }

        adapter.Dispose();

        LogService.Log("CourseService", "AddCourses");
    }

    public void ModifyCourses(CourseVO[] pOriginalCourses, CourseVO[] pNewCourses, bool isForced=false)
    {
        AuthenticationService.CheckIfUSerIsAuthenticated();
        CourseTableAdapter adapter = new CourseTableAdapter();

        for (int i = 0; i < Math.Min(pOriginalCourses.Length, pNewCourses.Length); ++i)
        {
            ONyRDataSet.CourseRow row = adapter.GetDataByID(pNewCourses[i].ID)[0];
            CourseVO vo = new CourseVO(row.ID, row.CourseName, row.Name);

            if (vo.Equals(pOriginalCourses[i]) || isForced)
            {
                adapter.Update(pNewCourses[i].CourseName, pNewCourses[i].Name, pNewCourses[i].ID);
            }
            else
            {
                LogService.LogError(LogService.ErrorCode.ModifyConflict);
                throw new Exception(((int)LogService.ErrorCode.ModifyConflict).ToString());
            }
        }

        adapter.Dispose();

        LogService.Log("CourseService", "ModifyCourses");
    }

}
