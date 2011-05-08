using ONyR_client.control.business.delegates;
using ONyR_client.control.business.responders;
using ONyR_client.control.notifiers.Course;

namespace ONyR_client.control.commands.Course
{
    class ModifyCoursesCommand : Command<ModifyCoursesNotifier>
    {
        override protected void execute(ModifyCoursesNotifier pModifyCoursesNotifier)
        {
            new CourseServiceDelegate(
                    pModifyCoursesNotifier,
                    new CourseServiceResponder()
                ).ModifyCourses(pModifyCoursesNotifier.OriginalCourses, pModifyCoursesNotifier.ModifiedCourses, pModifyCoursesNotifier.isForced);
        }
    }
}
