using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_client.Models;
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
       
        public async Task<IActionResult> GetAllCourses()
        {
            List<CourseMvcModel> courseList = new List<CourseMvcModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44364/api/Course"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    courseList = JsonConvert.DeserializeObject<List<CourseMvcModel>>(apiResponse);
                }
            }
            return View(courseList);
        }
    }
}
