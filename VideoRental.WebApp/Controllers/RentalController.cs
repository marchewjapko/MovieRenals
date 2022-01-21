using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

            if (!User.IsInRole("admin"))
            {
                string _restpath = GetHostUrl().Content + CN();
                List<RentalVM> rentals = new List<RentalVM>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_restpath}/filter user?userId={_userManager.FindByNameAsync(User.Identity.Name).Result.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        rentals = JsonConvert.DeserializeObject<List<RentalVM>>(apiResponse);
                    }
                }

                List<ListRentalVM> newRentals = new List<ListRentalVM>();
                foreach (var rental in rentals)
                {
                    newRentals.Add(new ListRentalVM()
                    {
                        Id = rental.Id,
                        Username = _userManager.FindByIdAsync(rental.IdUser).Result.UserName,
                        movieDTO = rental.movieDTO,
                        RentalDate = rental.RentalDate
                    });
                }
                return View("Index", newRentals);
            }
            else
            {
                string _restpath = GetHostUrl().Content + CN();
                List<RentalVM> rentals = new List<RentalVM>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        rentals = JsonConvert.DeserializeObject<List<RentalVM>>(apiResponse);
                    }
                }
                List<ListRentalVM> newRentals = new List<ListRentalVM>();
                foreach (var rental in rentals)
                {
                    newRentals.Add(new ListRentalVM()
                    {
                        Id = rental.Id,
                        Username = _userManager.FindByIdAsync(rental.IdUser).Result.UserName,
                        movieDTO = rental.movieDTO,
                        RentalDate = rental.RentalDate
                    });
                }
                return View(newRentals);
            }
        }
        public async Task<IActionResult> RentMovie(int id)
        {
            if (User.IsInRole("admin"))
            {
                return RedirectToAction(nameof(Index));
            }

            if(IfMovieAlreadyRented(id).Result)
                return RedirectToAction(nameof(Index));

            SendRentalVM c = new SendRentalVM()
            {
                IdUser = _userManager.FindByNameAsync(User.Identity.Name).Result.Id,
                IdMovie = id,
                RentalDate = DateTime.Now
            };
            string _restpath = GetHostUrl().Content + CN();
            RentalVM sjResult = new RentalVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    Console.WriteLine(jsonString);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<RentalVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {                
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            RentalVM c = new RentalVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<RentalVM>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SendRentalVM c)
        {
            Console.WriteLine(c.Id);
            string _restpath = GetHostUrl().Content + CN();
            SendRentalVM sjResult = new SendRentalVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    Console.WriteLine(jsonString);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{c.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<SendRentalVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IfMovieAlreadyRented(int movieId)
        {
            string _restpath = GetHostUrl().Content + CN();
            List<RentalVM> rentals = new List<RentalVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/filter user?userId={_userManager.FindByNameAsync(User.Identity.Name).Result.Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rentals = JsonConvert.DeserializeObject<List<RentalVM>>(apiResponse);
                }
            }
            foreach (var rental in rentals)
            {
                if (rental.movieDTO.Id == movieId)
                    return true ;
            }
            return false;
        }
    }
}
