using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.Course;

namespace ONyR_client.control.commands.Course
{
    class RemoveCoursesCommand : Command<RemoveCoursesNotifier>
    {
        override protected void execute(RemoveCoursesNotifier pRemoveCoursesNotifier)
        {
            new CourseServiceDelegate(
                    pRemoveCoursesNotifier,
                    new CourseServiceResponder()
                ).RemoveCourses(pRemoveCoursesNotifier.Courses);
        }
    }
}
