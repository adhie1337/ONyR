using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ONyRDataSetTableAdapters;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class CourseService : ICourseService
{
    public List<CourseVO> LoadCourses(CourseFilter pFilter, int pId = -1, int[] pIds = null)
    {
        List<CourseVO> result = null;
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            LogService.Log("CourseService", "LoadCourses", String.Format("Filter:{0}; ID:{1}; IDs: {2}", pFilter, pId, pIds));

            CourseTableAdapter adapter = new CourseTableAdapter();
            ONyRDataSet.CourseDataTable table;
            result = new List<CourseVO>();


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
                throw new ONyRException(ErrorCode.UnknownError);
            }

            for (int i = 0; i < table.Count; ++i)
            {
                if (pFilter != CourseFilter.ByIds || pIds.Contains(table[i].ID))
                {
				   // TODO: Fill properties here
				   // TODO: try-catch block for every Nullable field!
                    result.Add(new CourseVO(table[i].ID, table[i].Name));
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

    public List<CourseVO> AddCourses(CourseVO[] pCourses)
    {
        List<CourseVO> result = new List<CourseVO>();
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            CourseTableAdapter adapter = new CourseTableAdapter();
            string logParams = "";

            foreach (CourseVO vo in pCourses)
            {
                if (logParams.Length > 0)
                {
                    logParams += ",\n";
                }

                // TODO: Fill properties here & Create "Smart Insert Stored Procedure in the dataset!
                vo.ID = (int)adapter.SmartInsert(vo.Name);
                result.Add(vo);

                // TODO: Fill properties here
                logParams += String.Format("Name:\"{0}\"", vo.Name);
            }

            adapter.Dispose();

            LogService.Log("CourseService", "AddCourses", logParams);
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

    public List<CourseVO> RemoveCourses(CourseVO[] pCourses)
    {
		List<CourseVO> result = null;
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            CourseTableAdapter adapter = new CourseTableAdapter();
            string logParams = "";

            foreach (CourseVO vo in pCourses)
            {
                if (logParams.Length > 0)
                {
                    logParams += ",\n";
                }

                adapter.Delete(vo.ID);
				result.Add(vo);

                // TODO: Fill properties here
                logParams += String.Format("ID:\"{1}\", Name:\"{1}\"", vo.ID, vo.Name);
            }

            adapter.Dispose();

            LogService.Log("CourseService", "RemoveCourses", logParams);
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

    public List<CourseVO> ModifyCourses(CourseVO[] pOriginalCourses, CourseVO[] pNewCourses, bool isForced = false)
    {
		List<CourseVO> result = new List<CourseVO>();
        try
        {
            AuthenticationService.CheckIfUSerIsAuthenticated();
            CourseTableAdapter adapter = new CourseTableAdapter();
            string logParams = "";
            bool modifyConflict = false;

            for (int i = 0; i < Math.Min(pOriginalCourses.Length, pNewCourses.Length); ++i)
            {
                ONyRDataSet.CourseRow row = adapter.GetDataByID(pNewCourses[i].ID)[0];
                // TODO: Fill properties here
				// TODO: Watch out for null values!

                CourseVO vo = new CourseVO(row.ID);

                if (vo.Equals(pOriginalCourses[i]) || isForced)
                {
                    if (logParams.Length > 0)
                    {
                        logParams += ",\n";
                    }

					result.Add(vo);

                    // TODO: Fill properties here
                    adapter.Update(pNewCourses[i].Name, vo.ID);
                    logParams += String.Format("Name:\"{0}\" => \"{1}\"", vo.Name, pNewCourses[i].Name);
                }
                else
                {
                    modifyConflict = true;
                }
            }

            adapter.Dispose();

            LogService.Log("CourseService", "ModifyCourses", logParams);
			
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
}
