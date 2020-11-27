using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvc_client.Controllers
{
    public class CourseMvc : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            List<CourseMvc> courseList = new List<CourseMvc>();
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44364/api/Course"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    courseList = JsonConvert.DeserializeObject<List<CourseMvc>>(apiResponse);
                }
            }
            return View(courseList);
        }
    }
}
