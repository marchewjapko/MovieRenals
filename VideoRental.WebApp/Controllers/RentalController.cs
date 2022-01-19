using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VideoRental.WebApp.Models;

namespace VideoRental.WebApp.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        public IConfiguration Configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public RentalController(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            Configuration = configuration;
            _userManager = userManager;
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
            if(!User.IsInRole("admin"))
            {
                return Redirect("~/Rental/viewAllMyRentals");
            }
            string _restpath = GetHostUrl().Content + CN();
            List<RentalVM> movies = new List<RentalVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<List<RentalVM>>(apiResponse);
                }
            }
            List<ListRentalVM> movieList = new List<ListRentalVM>();
            foreach(var movie in movies)
            {
                movieList.Add(new ListRentalVM()
                {
                    Id = movie.Id,
                    Username = _userManager.FindByIdAsync(movie.IdUser).Result.UserName,
                    movieDTO = movie.movieDTO
                });
            }
            return View(movieList);
        }

        public async Task<IActionResult> viewAllMyRentals()
        {            
            string _restpath = GetHostUrl().Content + CN();
            List<RentalVM> movies = new List<RentalVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/filter user?userId={_userManager.FindByNameAsync(User.Identity.Name).Result.Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<List<RentalVM>>(apiResponse);
                }
            }

            List<ListRentalVM> movieList = new List<ListRentalVM>();
            foreach (var movie in movies)
            {
                movieList.Add(new ListRentalVM()
                {
                    Id = movie.Id,
                    Username = _userManager.FindByIdAsync(movie.IdUser).Result.UserName,
                    movieDTO = movie.movieDTO
                });
            }
            return View("Index", movieList);
        }
    }
}
