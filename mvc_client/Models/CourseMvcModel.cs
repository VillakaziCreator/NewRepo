using System.ComponentModel.DataAnnotations;

namespace mvc_client.Models
{
    public class CourseMvcModel
    {
        [Key]
        public string CourseID { get; set; }
        public string Description { get; set; }
        public string CoursePath { get; set; }
        public string NumberOfStudents { get; set; }
    }
}
