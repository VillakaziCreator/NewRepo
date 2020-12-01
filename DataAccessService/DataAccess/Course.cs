using System.ComponentModel.DataAnnotations;

namespace DataAccessService.DataAccess
{
    public class Course
    {
        [Key]
        public string CourseID { get; set; }
        public string Description { get; set; }
        public string CoursePath { get; set; }
        public string NumberOfStudents { get; set; }

    }
}
