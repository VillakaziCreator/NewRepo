using System.ComponentModel.DataAnnotations;

namespace DataAccessService.DataAccess
{
    public class Student
    {
        [Key]
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
    }
}
