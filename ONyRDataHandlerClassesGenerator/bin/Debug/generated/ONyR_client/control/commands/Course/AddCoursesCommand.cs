using ONyR_client.control.notifiers.Course;
using ONyR_client.control.business.delegates;

namespace ONyR_client.control.commands.Course
{
    class AddCoursesCommand : Command<AddCoursesNotifier>
    {
        override protected void execute(AddCoursesNotifier pAddCoursesNotifier)
        {
            CourseServiceDelegate.AddCourses(pAddCoursesNotifier.Courses);
        }
    }
}
