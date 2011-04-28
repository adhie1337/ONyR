using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.Course
{
    class RemoveCoursesNotifier : Notifier
    {
        public RemoveCoursesNotifier(CourseVO[] pCourses)
        {
            mCourses = pCourses;
        }

        private CourseVO[] mCourses;

        public CourseVO[] Courses
        {
            get
            {
                return mCourses;
            }
        }
    }
}
