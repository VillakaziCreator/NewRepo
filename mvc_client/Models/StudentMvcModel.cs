using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_client.Models
{
    public class StudentMvcModel
    {
        [Key]
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
    }
}
