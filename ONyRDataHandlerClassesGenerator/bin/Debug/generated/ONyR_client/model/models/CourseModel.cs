using System.Collections.Generic;
using System.Linq;
using ONyR_client.model.vo;

namespace ONyR_client.model.models
{
    public class CourseModel : Model
    {

        #region Members

        private Dictionary<int, CourseVO> mCourses;

        #endregion

        #region Constructor

        public CourseModel()
        {
            mCourses = new Dictionary<int, CourseVO>();
        }

        #endregion

        #region Queries

        public CourseVO GetCourseByID(int pID)
        {
            return mCourses[pID].Clone();
        }

        public List<CourseVO> GetCoursesByIDs(int[] pIDs)
        {
            List<CourseVO> result = new List<CourseVO>();

            int[] keys = mCourses.Keys.ToArray();

            for (int i = 0; i < pIDs.Count(); ++i)
            {
                if (keys.Contains(pIDs[i]))
                {
                    result.Add(mCourses[pIDs[i]].Clone());
                }
            }

            return result;
        }

        public List<CourseVO> GetAllCourses()
        {
            List<CourseVO> result = new List<CourseVO>();

            int[] keys = mCourses.Keys.ToArray();

            for (int i = 0; i < keys.Count(); ++i)
            {
                result.Add(mCourses[keys[i]].Clone());
            }

            return result;
        }

        #endregion

        #region Model manipulation

        public void AddCourse(CourseVO pCourse)
        {
            mCourses[pCourse.ID] = pCourse;
            update();
        }

        public void AddCourses(CourseVO[] pCourses)
        {
            foreach (CourseVO vo in pCourses)
            {
                mCourses[vo.ID] = vo.Clone();
            }

            update();
        }

        public void RemoveCourseByID(int pID)
        {
            mCourses.Remove(pID);
        }

        public void RemoveCoursesByIDs(int[] pIDs)
        {
            for (int i = 0; i < pIDs.Count(); ++i)
            {
                mCourses.Remove(pIDs[i]);
            }
            update();
        }

        public void ModifyCourse(CourseVO pCourse)
        {
            AddCourse(pCourse);
        }

        public void ModifyCourses(CourseVO[] pCourses)
        {
            AddCourses(pCourses);
        }


        public void Empty()
        {
            int[] keys = mCourses.Keys.ToArray();

            for (int i = 0; i < keys.Count(); ++i)
            {
                mCourses.Remove(keys[i]);
            }

            update();
        }

        #endregion
    }
}
