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
    public class GenreController : Controller
    {
        public IConfiguration Configuration;

        public GenreController(IConfiguration configuration)
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
            List<GenreVM> genreList = new List<GenreVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    genreList = JsonConvert.DeserializeObject<List<GenreVM>>(apiResponse);
                }
            }
            return View(genreList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            GenreVM c = new GenreVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<GenreVM>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenreVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            GenreVM sjResult = new GenreVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    Console.WriteLine(jsonString);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{_restpath}/{c.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<GenreVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            GenreVM sjResult = new GenreVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<GenreVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            GenreVM c = new GenreVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<GenreVM>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GenreVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            GenreVM sjResult = new GenreVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{c.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<GenreVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GenreMovies(int id)
        {
            string _restpath = GetHostUrl().Content + "Movie";
            return Redirect("~/Movie/GetByGenre/" + id);
        }
    }
}
