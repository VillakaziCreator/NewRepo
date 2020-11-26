using Microsoft.AspNetCore.Mvc;
using mvc_client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


      
        public async Task<IActionResult> UpdateStudent(string studNum)
        {
            StudentMvcModel studentToUpdate = new StudentMvcModel();
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44364/api/Student/" + studNum))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentToUpdate = JsonConvert.DeserializeObject<StudentMvcModel>(apiResponse);
                }
            }
                return View(studentToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(StudentMvcModel student)
        {
            using (var httpClient = new HttpClient())
            {
                string serailizedStudent = JsonConvert.SerializeObject(student);

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(serailizedStudent, Encoding.UTF8,"application/json")
                };

                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = httpClient.PutAsync("https://localhost:44364/api/Student", inputMessage.Content).Result;

                if (!responseMessage.IsSuccessStatusCode)
                    throw new ArgumentException(responseMessage.ToString());
            }

            return RedirectToAction("Index");
        }

    }
}

