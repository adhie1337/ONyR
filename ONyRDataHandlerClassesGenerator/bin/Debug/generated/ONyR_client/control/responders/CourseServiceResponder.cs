using ONyR_client.model.vo;
using ONyR_client.model;

namespace ONyR_client.control.business.responders
{
    class CourseServiceResponder
    {

        public static void LoadCoursesResult(CourseVO[] pLoadedCourses)
        {
            ModelLocator locator = ModelLocator.getInstance();

            for (int i = 0; i < pLoadedCourses.Length; ++i)
            {
                if (pLoadedCourses[i].ID == locator.SessionModel.CourseId)
                {
                    locator.SessionModel.SetCurrentCourse(pLoadedCourses[i]);
                }
            }

            locator.CourseModel.AddCourses(pLoadedCourses);
        }

        public static void LoadCoursesFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode);
        }

        public static void AddCoursesResult(CourseVO[] pAddedCourses)
        {
            ModelLocator.getInstance().CourseModel.AddCourses(pAddedCourses);
        }

        public static void AddCoursesFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode);
        }

        public static void RemoveCoursesResult(CourseVO[] pRemovedCourses)
        {
            ModelLocator locator = ModelLocator.getInstance();
            int[] ids = new int[pRemovedCourses.Length];

            for (int i = 0; i < pRemovedCourses.Length; ++i)
            {
                ids[i] = pRemovedCourses[i].ID;
            }

            locator.CourseModel.RemoveCoursesByIDs(ids);
        }

        public static void RemoveCoursesFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode);
        }

        public static void ModifyCoursesResult(CourseVO[] pNewCourses)
        {
            ModelLocator.getInstance().CourseModel.ModifyCourses(pNewCourses);
        }

        public static void ModifyCoursesFault(ErrorCode pCode)
        {
            ApplicationFaultManager.Fault(pCode);
        }

    }
}
