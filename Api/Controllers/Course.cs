using Api.DataAccess;
using Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course : ControllerBase
    {
        private readonly DataAccessContext _context;


        public Course(DataAccessContext context)
        {
            _context = context;    
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetAllCourses()
        {
            return await _context.Courses
                .Select(x => new CourseModel()
                {
                    CourseID = x.CourseID,
                    Description = x.Description,
                    CoursePath = x.CoursePath,
                    NumberOfStudents = x.NumberOfStudents
                }).ToListAsync();
        }
    }
}
