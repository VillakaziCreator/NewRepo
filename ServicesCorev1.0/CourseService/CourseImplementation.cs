using DataAccessService.DataAccess;
using ModelsCore.CourseModelCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesCorev1._0.CourseService
{
    public class CourseImplementation : ICourseInterface
    {
        private readonly DataAccessContext dbcontext;

        public CourseImplementation(DataAccessContext _context)
        {
            dbcontext = _context;
        }
        public CourseModel AddCourse(CourseModel model)
        {
            using (dbcontext)
            {
                if (model != null)
                {
                    Course course = new Course
                    {
                        CourseID = model.CourseID,
                        Description = model.Description,
                        CoursePath = model.CoursePath,
                        NumberOfStudents = model.NumberOfStudents
                    };
                    _ = dbcontext.Courses.Add(course);
                    _ = dbcontext.SaveChanges();
                    return model;
                }
            }
            return model;
        }

        public CourseModel DeleteCourse(string id)
        {
            throw new NotImplementedException();
        }

        public CourseModel FindCourseById(string id)
        {
            using (dbcontext)
            {
                CourseModel couserModel = dbcontext.Courses.Select(x => new CourseModel
                {
                    CourseID = x.CourseID,
                    Description = x.Description,
                    CoursePath = x.CoursePath,
                    NumberOfStudents = x.NumberOfStudents
                }).FirstOrDefault(b => b.CourseID == id);

                return couserModel;
            }
        }

        public List<CourseModel> GetAllCourses()
        {
            using (dbcontext)
            {
                return dbcontext.Courses.Select(x => new CourseModel
                {
                    CourseID = x.CourseID,
                    Description = x.Description,
                    CoursePath = x.CoursePath,
                    NumberOfStudents = x.NumberOfStudents
                }).ToList();
            }
        }

        public string UpdateCourse(CourseModel model)
        {
            try
            {
                using (dbcontext)
                {
                    Course course = dbcontext.Courses.Find(model.CourseID);

                    course.CourseID = model.CourseID;
                    course.Description = model.Description;
                    course.CoursePath = model.CoursePath;
                    course.NumberOfStudents = model.NumberOfStudents;

                    dbcontext.Update(course);
                    dbcontext.SaveChanges();
                    return $"Group {model.Description} successfully updated!";
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
