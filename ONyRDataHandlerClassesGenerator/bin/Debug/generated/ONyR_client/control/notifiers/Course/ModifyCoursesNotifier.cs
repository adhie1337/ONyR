using ONyR_client.model.vo;

namespace ONyR_client.control.notifiers.Course
{
    class ModifyCoursesNotifier : Notifier
    {
        private CourseVO[] mOriginalCourses;

        private CourseVO[] mModifiedCourses;

        public ModifyCoursesNotifier(CourseVO[] pOriginalCourses, CourseVO[] pModifiedCourses)
        {
            mOriginalCourses = pOriginalCourses;
            mModifiedCourses = pModifiedCourses;
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

        public override object Clone()
        {
            return new ModifyCoursesNotifier(mOriginalCourses, mModifiedCourses);
        }
    }
}
