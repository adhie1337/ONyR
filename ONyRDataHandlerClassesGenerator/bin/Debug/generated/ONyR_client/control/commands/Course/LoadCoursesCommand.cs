using ONyR_client.control.notifiers.Course;
using ONyR_client.control.business.delegates;

namespace ONyR_client.control.commands.Course
{
    class LoadCoursesCommand : Command<LoadCoursesNotifier>
    {
        override protected void execute(LoadCoursesNotifier pLoadCoursesNotifier)
        {
            CourseServiceDelegate.LoadCourses((CourseServiceSkeleton.CourseFilter)pLoadCoursesNotifier.Filter, pLoadCoursesNotifier.Id, pLoadCoursesNotifier.Ids);
        }
    }
}
