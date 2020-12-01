using System.ComponentModel.DataAnnotations;

namespace ModelsCore.CourseModelCore
{
    public class CourseModel
    {
        [Key]
        public string CourseID { get; set; }
        public string Description { get; set; }
        public string CoursePath { get; set; }
        public string NumberOfStudents { get; set; }

    }

}
