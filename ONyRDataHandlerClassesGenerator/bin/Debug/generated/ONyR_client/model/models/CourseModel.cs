using System.Collections.Generic;
using System.Linq;
using ONyR_client.model.vo;

namespace ONyR_client.model.models
{
    class CourseModel : Model
    {

        #region Constructor

        public CourseModel()
        {
            mCourses = new List<CourseVO>();
        }

        #endregion

        #region Properties

        private List<CourseVO> mCourses;

        #endregion

        #region Queries

        public CourseVO GetCourseByID(int pID)
        {
            for (int i = 0; i < mCourses.Count; ++i)
            {
                if (mCourses[i].ID == pID)
                {
                    return mCourses[i].Clone();
                }
            }

            return null;
        }

        public List<CourseVO> GetCoursesByIDs(int[] pIDs)
        {
            List<CourseVO> retVal = new List<CourseVO>();

            for (int i = 0; i < mCourses.Count; ++i)
            {
                if (pIDs.Contains(mCourses[i].ID))
                {
                    retVal.Add(mCourses[i].Clone());
                }
            }

            return retVal;
        }

        public List<CourseVO> GetAllCourses()
        {
            List<CourseVO> retVal = new List<CourseVO>();

            for (int i = 0; i < mCourses.Count; ++i)
            {
                retVal.Add(mCourses[i].Clone());
            }

            return retVal;
        }

        #endregion

        #region Model manipulation

        public void AddCourse(CourseVO pCourse)
        {
            mCourses.Add(pCourse);
            update();
        }

        public void AddCourses(CourseVO[] pCourses)
        {
            mCourses.AddRange(pCourses);
            update();
        }

        public void RemoveCourseByID(int pID)
        {
            for (int i = 0; i < mCourses.Count; ++i)
            {
                if (mCourses[i].ID == pID)
                {
                    mCourses.RemoveAt(i);
                    update();
                    break;
                }
            }
        }

        public void RemoveCoursesByIDs(int[] pIDs)
        {
            for (int i = 0; i < mCourses.Count; ++i)
            {
                if (pIDs.Contains(mCourses[i].ID))
                {
                    mCourses.RemoveAt(i);
                    --i;
                }
            }
            update();
        }

        public void ModifyCourse(CourseVO pCourse)
        {
            for (int i = 0; i < mCourses.Count; ++i)
            {
                if (mCourses[i].ID == pCourse.ID)
                {
                    mCourses.RemoveAt(i);
                    break;
                }
            }

            mCourses.Add(pCourse);
            update();
        }

        public void ModifyCourses(CourseVO[] pCourses)
        {
            for (int i = 0; i < mCourses.Count; ++i)
            {
                if (pCourses.Contains(mCourses[i]))
                {
                    mCourses.RemoveAt(i);
                    --i;
                }
            }

            mCourses.AddRange(pCourses);
            update();
        }


        public void Empty()
        {
            mCourses.RemoveRange(0, mCourses.Count);
            update();
        }

        #endregion
    }
}
