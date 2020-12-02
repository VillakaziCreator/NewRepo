using DataAccessService.DataAccess;
using Models.Student;
using ServicesCorev1._0.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesCore.Student
{
    public class StudentImplementation : IStudentInterface
    {
        private readonly DataAccessContext dbcontext;

        public StudentImplementation(DataAccessContext _context)
        {
            dbcontext = _context;
        }
        public StudentModel AddStudent(StudentModel model)
        {
            using (dbcontext)
            {
                if (model != null)
                {
                    DataAccessService.DataAccess.Student student = new DataAccessService.DataAccess.Student
                    {
                        FirstName = model.FirstName,
                        StudentNumber = model.StudentNumber
                    };

                    _ = dbcontext.Students.Add(student);
                    _ = dbcontext.SaveChanges();
                    return model;
                }
                return model;
            }
        }

        public StudentModel DeleteStudent(string id)
        {
            throw new NotImplementedException();
        }

        public StudentModel FindStudentById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<StudentModel> GetAllStudents()
        {
            using (dbcontext)
            {
                return dbcontext.Students.Select(x => new StudentModel
                {
                    FirstName = x.FirstName,
                    StudentNumber = x.StudentNumber
                }).ToList();
            }
        }

        public StudentModel UpdateStudent(StudentModel model)
        {
            try
            {
                //using (dbcontext)
                //{
                DataAccessService.DataAccess.Student student = dbcontext.Students.Find(model.StudentNumber);

                student.StudentNumber = model.StudentNumber;
                student.FirstName = model.FirstName;

                dbcontext.Students.Update(student);
                dbcontext.SaveChanges();

                return model;
                //};
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
