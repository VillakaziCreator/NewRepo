using Microsoft.AspNetCore.Mvc;
using mvc_client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mvc_client.Controllers
{
    public class StudentMvcController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<StudentMvcModel> studentList = new List<StudentMvcModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44364/api/Student"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentList = JsonConvert.DeserializeObject<List<StudentMvcModel>> (apiResponse);
                }
            }
            return View(studentList);
        }

        public ViewResult AddStudent() => View();

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentMvcModel student)
        {
            StudentMvcModel receivedStudent = new StudentMvcModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44364/api/Student", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedStudent = JsonConvert.DeserializeObject<StudentMvcModel>(apiResponse);
                }
            }

            // ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction(nameof(Index));
        }

    }
}

