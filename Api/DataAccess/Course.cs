using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DataAccess
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
