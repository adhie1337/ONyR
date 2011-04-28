using ONyR_client.control.notifiers.Course;
using ONyR_client.control.business.delegates;

namespace ONyR_client.control.commands.Course
{
    class ModifyCoursesCommand : Command<ModifyCoursesNotifier>
    {
        override protected void execute(ModifyCoursesNotifier pModifyCoursesNotifier)
        {
            CourseServiceDelegate.ModifyCourses(pModifyCoursesNotifier.OriginalCourses, pModifyCoursesNotifier.ModifiedCourses, pModifyCoursesNotifier.isForced);
        }
    }
}
