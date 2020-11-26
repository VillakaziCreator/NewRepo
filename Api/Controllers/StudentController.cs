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
        public async Task<ActionResult<Student>> PostStudentModel([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStudentModel", new { id = student.StudentNumber }, student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentModel(string id)
        {
            var studentModel = await _context.Students.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;

        }

        [HttpPut("{id}")]
        [AcceptVerbs("PUT","POST")]
        public async Task<IActionResult> UpdateStudentModel([FromForm] Student student)
        {
            if (student.StudentNumber == null)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(string id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

    }
}
