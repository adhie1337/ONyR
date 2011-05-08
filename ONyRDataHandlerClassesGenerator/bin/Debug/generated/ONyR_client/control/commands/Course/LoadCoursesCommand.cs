using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.Course;

namespace ONyR_client.control.commands.Course
{
    class LoadCoursesCommand : Command<LoadCoursesNotifier>
    {
        override protected void execute(LoadCoursesNotifier pLoadCoursesNotifier)
        {
            new CourseServiceDelegate(
                pLoadCoursesNotifier,
                new CourseServiceResponder()
            ).LoadCourses((CourseServiceReference.CourseFilter)pLoadCoursesNotifier.Filter, pLoadCoursesNotifier.Id, pLoadCoursesNotifier.Ids);
        }
    }
}
