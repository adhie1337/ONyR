using ONyR_client.control.notifiers.Course;
using ONyR_client.control.business.delegates;

namespace ONyR_client.control.commands.Course
{
    class RemoveCoursesCommand : Command<RemoveCoursesNotifier>
    {
        override protected void execute(RemoveCoursesNotifier pRemoveCoursesNotifier)
        {
            CourseServiceDelegate.RemoveCourses(pRemoveCoursesNotifier.Courses);
        }
    }
}
