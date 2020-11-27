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
        public async Task<ActionResult<IEnumerable<Model.CourseModel>>> GetAllCourses()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseById(string id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            return course;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("PUT","POST")]
        public async Task<IActionResult> UpdateCourse([FromForm] CourseModel course)
        {
            if (course.CourseID == null)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }


    }
}
