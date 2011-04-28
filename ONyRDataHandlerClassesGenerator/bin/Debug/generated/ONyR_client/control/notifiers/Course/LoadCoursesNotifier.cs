namespace ONyR_client.control.notifiers.Course
{
    class LoadCoursesNotifier : Notifier
    {
        public enum CourseFilter
        {
            ById=0, ByIds, All
        };

        public LoadCoursesNotifier(CourseFilter pFilter, int pId = -1, int[] pIds = null)
        {
            mfeFilter = pFilter;
            miId = pId;
            maIds = pIds;
        }

        private CourseFilter mfeFilter;
        private int miId;
        private int[] maIds;

        public CourseFilter Filter
        {
            get
            {
                return mfeFilter;
            }
        }

        public int Id
        {
            get
            {
                if (mfeFilter == CourseFilter.ById)
                {
                    return miId;
                }

                return -1;
            }
        }

        public int[] Ids
        {
            get
            {
                if (mfeFilter == CourseFilter.ByIds)
                {
                    return maIds;
                }

                return null;
            }
        }
    }
}
