using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class MovieController : Controller
    {
        public IConfiguration Configuration;

        public MovieController(IConfiguration configuration)
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
            List<MovieVM> movieList = new List<MovieVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<List<MovieVM>>(apiResponse);
                }
            }
            return View(movieList);
        }

        public async Task<IActionResult> GetByDirector(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            List<MovieVM> movieList = new List<MovieVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/filter director?directorId={id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<List<MovieVM>>(apiResponse);
                }
            }
            return View("Index", movieList);
        }

        public async Task<IActionResult> GetByGenre(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            List<MovieVM> movieList = new List<MovieVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/filter genre?genreId={id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<List<MovieVM>>(apiResponse);
                }
            }
            return View("Index", movieList);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            string _restpath = GetHostUrl().Content + "Genre";
            List<GenreVM> genreList = new List<GenreVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    genreList = JsonConvert.DeserializeObject<List<GenreVM>>(apiResponse);
                }
            }

            _restpath = GetHostUrl().Content + "Director";
            List<DirectorVM> directorList = new List<DirectorVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    directorList = JsonConvert.DeserializeObject<List<DirectorVM>>(apiResponse);
                }
            }

            var c = new AddMovieVM(genreList, directorList);
            c.ReleaseDate = DateTime.Now;
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieVM a)
        {
            var newMovie = new SendMovieVM()
            {
                Name = a.Name,
                IdGenre = a.IdGenre,
                ReleaseDate = a.ReleaseDate,
                IdDirector = a.IdDirector,
                AgeRating = a.AgeRating,
                Description = a.Description,
                Rating = a.Rating
            };
            string _restpath = GetHostUrl().Content + CN();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(newMovie);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            MovieVM c = new MovieVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<MovieVM>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GenreVM c)
        {
            string _restpath = GetHostUrl().Content + CN();
            MovieVM sjResult = new MovieVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{c.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<MovieVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {            
            string _restpath = GetHostUrl().Content + CN();
            MovieVM c = new MovieVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<MovieVM>(apiResponse);
                }
            }

            _restpath = GetHostUrl().Content + "Genre";
            List<GenreVM> genreList = new List<GenreVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    genreList = JsonConvert.DeserializeObject<List<GenreVM>>(apiResponse);
                }
            }

            _restpath = GetHostUrl().Content + "Director";
            List<DirectorVM> directorList = new List<DirectorVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    directorList = JsonConvert.DeserializeObject<List<DirectorVM>>(apiResponse);
                }
            }

            var updateMovie = new UpdateMovieVM(genreList, directorList, c.Genre, c.Director);
            updateMovie.Id = c.Id;
            updateMovie.Name = c.Name;
            updateMovie.IdGenre = c.Genre.Id;
            updateMovie.ReleaseDate = c.ReleaseDate;
            updateMovie.IdDirector = c.Director.Id;
            updateMovie.AgeRating = c.AgeRating;
            updateMovie.Description = c.Description;
            updateMovie.Rating = c.Rating;
            return View(updateMovie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMovieVM a)
        {
            var newMovie = new SendMovieVM()
            {
                Id = a.Id,
                Name = a.Name,
                IdGenre = a.IdGenre,
                ReleaseDate = a.ReleaseDate,
                IdDirector = a.IdDirector,
                AgeRating = a.AgeRating,
                Description = a.Description,
                Rating = a.Rating
            };
            string _restpath = GetHostUrl().Content + CN();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(newMovie);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{_restpath}/{newMovie.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
