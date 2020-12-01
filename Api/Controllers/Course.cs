using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelsCore.CourseModelCore;
using ServicesCorev1._0.CourseService;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course : ControllerBase
    {
        private readonly ICourseInterface _courseInterface;


        public Course(ICourseInterface courseInterface)
        {
            _courseInterface = courseInterface;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CourseModel>> GetAllCourses()
        {
            return _courseInterface.GetAllCourses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseById(int id)
        {
            CourseModel course = _courseInterface.FindCourseById(id);
            return course == null ? NotFound() : (ActionResult<CourseModel>)course;
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> PostCourse([FromBody] CourseModel course)
        {
            CourseModel courseModel = _courseInterface.AddCourse(course);
            return CreatedAtAction("GetAllCourses", new { id = courseModel.CourseID }, courseModel);
        }

        [HttpPut("{id}")]
        [AcceptVerbs("PUT")]
        public ActionResult<CourseModel> UpdateCourse([FromForm] CourseModel course)
        {
            try
            {
                if (course.CourseID == null)
                {
                    return BadRequest();
                }
                string a = _courseInterface.UpdateCourse(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return course;
        }


    }
}
