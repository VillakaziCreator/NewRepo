using Api.DataAccess;
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
    public class StudentController : ControllerBase
    {
        private readonly DataAccessContext _context;

        public StudentController(DataAccessContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentModel()
        {
            return await _context.Students
                .Select(x => new Student()
                {
                    StudentNumber = x.StudentNumber,
                    FirstName = x.FirstName
                    
                }).ToListAsync();
        }

        [HttpPost]
        public ActionResult<Student> PostStudentModel([FromForm] Student student)
        {
            return CreatedAtAction("GetStudentModel", new { id = student.StudentNumber }, student);
        }
    }

}
