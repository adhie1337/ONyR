using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.model.models;

namespace ONyR_client.model
{
    public class ModelLocator
    {
        #region Singleton design pattern implementation

        private static ModelLocator instance;

        public static ModelLocator getInstance()
        {
            if (instance == null)
            {
                instance = new ModelLocator();
            }
            return instance;
        }

        #endregion

        #region Constructor

        private ModelLocator()
        {
            SessionModel = new SessionModel();
            CourseModel = new CourseModel();
            ExamModel = new ExamModel();
            FacultyModel = new FacultyModel();
            PostModel = new PostModel();
            ProgrammeModel = new ProgrammeModel();
            UniversityModel = new UniversityModel();
            UserModel = new UserModel();
            SemesterModel = new SemesterModel();
            LogModel = new LogModel();
        }

        #endregion

        #region Models

        public SessionModel SessionModel;
        public CourseModel CourseModel;
        public ExamModel ExamModel;
        public FacultyModel FacultyModel;
        public PostModel PostModel;
        public ProgrammeModel ProgrammeModel;
        public UniversityModel UniversityModel;
        public UserModel UserModel;
        public SemesterModel SemesterModel;
        public LogModel LogModel;

        #endregion
    }
}
