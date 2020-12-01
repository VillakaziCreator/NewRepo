using System.ComponentModel.DataAnnotations;

namespace Models.Student
{
    public class StudentModel
    {
        [Key]
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
    }
}
