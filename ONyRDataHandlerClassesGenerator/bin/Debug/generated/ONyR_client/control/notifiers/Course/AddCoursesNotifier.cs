using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.Course
{
    class AddCoursesNotifier : Notifier
    {
        public AddCoursesNotifier(CourseVO[] pCourses)
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

        override public object Clone()
        {
            return new AddCoursesNotifier(mCourses);
        }
    }
}
