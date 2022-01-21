using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VideoRental.WebApp.Models;

namespace VideoRental.WebApp.Controllers
{
    public class DirectorController : Controller
    {
        public IConfiguration Configuration;

        public DirectorController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            return Content(Configuration["RestApiUrl:HostUrl"]);
        }

        private string CN()
        {
            return ControllerContext.RouteData.Values["Controller"].ToString();
        }

        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<DirectorVM> directorList = new List<DirectorVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    directorList = JsonConvert.DeserializeObject<List<DirectorVM>>(apiResponse);
                }
            }
            return View(directorList);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            DirectorVM c = new DirectorVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<DirectorVM>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DirectorVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            DirectorVM sjResult = new DirectorVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{_restpath}/{c.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<DirectorVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirectorVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            DirectorVM sjResult = new DirectorVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<DirectorVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            DirectorVM c = new DirectorVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<DirectorVM>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DirectorVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            DirectorVM sjResult = new DirectorVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{c.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<DirectorVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DirectorMovies(int id)
        {
            string _restpath = GetHostUrl().Content + "Movie";
            return Redirect("~/Movie/GetByDirector/" + id);
        }
    }
}
