using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelsCore.CourseModelCore;
using ServicesCorev1._0.CourseService;
using System;

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
        public async Task<ActionResult<CourseModel>> GetCourseById(string id)
        {
            CourseModel course = _courseInterface.FindCourseById(id);
            if (course == null)
                return NotFound();
            return course;
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> PostCourse([FromBody] CourseModel course)
        {
            CourseModel courseModel = _courseInterface.AddCourse(course);
            return courseModel;
        }

        /*[HttpPut("{id}")]
        [AcceptVerbs("PUT","POST")]
        public ActionResult<CourseModel> UpdateCourse([FromForm] CourseModel course)
        {
            try
            {
                if (course.CourseID == null)
                {
                    return BadRequest();
                }
                string a = _courseInterface.UpdateCourse(course);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }*/

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<CourseModel> UpdateCourse(string id, CourseModel model)
        {
            try
            {
                if ((model == null) || (model.CourseID == ""))
                {
                    return NotFound();
                }
                _courseInterface.UpdateCourse(model);
                return model;

            }
            catch (Exception)
            {
                
                 throw;
                
            }
            
        }



    }
}
