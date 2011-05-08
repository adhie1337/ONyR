namespace ONyR_client.control.notifiers.Course
{
    public enum CourseFilter
    {
		// TODO: Change this
        ById=0, ByIds, All
    }

    class LoadCoursesNotifier : Notifier
    {

        public LoadCoursesNotifier(CourseFilter pFilter, int pId = -1, int[] pIds = null)
        {
            mFilter = pFilter;
            mId = pId;
            mIds = pIds;
        }

        private CourseFilter mFilter;
        private int mId;
        private int[] mIds;

        public CourseFilter Filter
        {
            get
            {
                return mFilter;
            }
        }

        public int Id
        {
            get
            {
                if (mFilter == CourseFilter.ById)
                {
                    return mId;
                }

                return -1;
            }
        }

        public int[] Ids
        {
            get
            {
                if (mFilter == CourseFilter.ByIds)
                {
                    return mIds;
                }

                return null;
            }
        }


        override public object Clone()
        {
            return new LoadCoursesNotifier(mFilter, mId, mIds);
        }
    }
}
