using Models.Student;
using System.Collections.Generic;

namespace ServicesCorev1._0.StudentService
{
    public interface IStudentInterface
    {
        public StudentModel AddStudent(StudentModel model);
        public StudentModel FindStudentById(int Id);
        public List<StudentModel> GetAllStudents();
        public StudentModel UpdateStudent(StudentModel model);
        public StudentModel DeleteStudent(string id);
    }
}
