using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Student;
using ServicesCorev1._0.StudentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _studentService;

        public StudentController(IStudentInterface studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModel()
        {
            return _studentService.GetAllStudents();
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel([FromBody] StudentModel student)
        {
            StudentModel student_ = _studentService.AddStudent(student);
            return student_;
            ///return CreatedAtAction("GetStudentModel", new { id = student.StudentNumber }, student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(int id)
        {
            StudentModel studentModel = _studentService.FindStudentById(id);

            return studentModel == null ? NotFound() : (ActionResult<StudentModel>)studentModel;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("PUT")]
        public ActionResult<StudentModel> UpdateStudentModel([FromBody] StudentModel student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                StudentModel _student = _studentService.UpdateStudent(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return student;

        }

        [HttpDelete("{id}")]
        public ActionResult<StudentModel> DeleteStudent(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            return _studentService.DeleteStudent(id);
            // }
        }

    }
}
