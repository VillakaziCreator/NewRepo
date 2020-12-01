using Microsoft.AspNetCore.Mvc;
using mvc_client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mvc_client.Controllers
{
    public class CourseMvc : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            List<CourseMvcModel> courseList = new List<CourseMvcModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44364/api/Course");
                string apiResponse = await response.Content.ReadAsStringAsync();
                courseList = JsonConvert.DeserializeObject<List<CourseMvcModel>>(apiResponse);
            }
            return View(courseList);
        }


        public ViewResult NewCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewCourse(CourseMvcModel course)
        {
            CourseMvcModel receivedCourse = new CourseMvcModel();
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
                using HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44364/api/Course", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                receivedCourse = JsonConvert.DeserializeObject<CourseMvcModel>(apiResponse);
            }

            return RedirectToAction(nameof(GetAllCourses));
        }
    }
}
