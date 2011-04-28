using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.Course
{
    class ModifyCoursesNotifier : Notifier
    {
        private CourseVO[] mOriginalCourses;

        private CourseVO[] mModifiedCourses;

        private bool mIsForced;

        public ModifyCoursesNotifier(CourseVO[] pOriginalCourses, CourseVO[] pModifiedCourses, bool pIsForced = false)
        {
            mOriginalCourses = pOriginalCourses;
            mModifiedCourses = pModifiedCourses;
            this.mIsForced = pIsForced;
        }

        public CourseVO[] OriginalCourses
        {
            get
            {
                return mOriginalCourses;
            }
        }

        public CourseVO[] ModifiedCourses
        {
            get
            {
                return mModifiedCourses;
            }
        }

        public bool isForced
        {
            get
            {
                return mIsForced;
            }
        }
    }
}
