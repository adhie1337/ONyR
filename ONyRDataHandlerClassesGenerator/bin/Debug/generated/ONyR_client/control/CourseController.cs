using ONyR_client.control.notifiers.Course;
using ONyR_client.control.commands.Course;

namespace ONyR_client.control
{
    class CourseController : FrontController
    {
        override protected void Initialize()
        {
            addConnection(typeof(LoadCoursesNotifier), typeof(LoadCoursesCommand));
            addConnection(typeof(AddCoursesNotifier), typeof(AddCoursesCommand));
            addConnection(typeof(ModifyCoursesNotifier), typeof(ModifyCoursesCommand));
            addConnection(typeof(RemoveCoursesNotifier), typeof(RemoveCoursesCommand));
        }
    }
}
