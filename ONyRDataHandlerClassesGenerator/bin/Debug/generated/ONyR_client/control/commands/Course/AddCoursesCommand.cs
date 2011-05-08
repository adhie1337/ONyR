using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.Course;

namespace ONyR_client.control.commands.Course
{
    class AddCoursesCommand : Command<AddCoursesNotifier>
    {
        override protected void execute(AddCoursesNotifier pAddCoursesNotifier)
        {
            new CourseServiceDelegate(
                    pAddCoursesNotifier,
                    new CourseServiceResponder()
                ).AddCourses(pAddCoursesNotifier.Courses);
        }
    }
}
