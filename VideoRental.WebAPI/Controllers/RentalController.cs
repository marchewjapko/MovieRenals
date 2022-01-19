using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;
using VideoRental.Infrastructure.Services;

namespace VideoRental.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllAsync()
        {
            IEnumerable<RentalDTO> z = await _rentalService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRental(int id)
        {
            RentalDTO z = await _rentalService.GetRental(id);
            return Json(z);
        }

        [HttpPost]
        public async Task AddRental([FromBody] CreateRental genre)
        {
            await _rentalService.AddRental(genre);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRental(int id)
        {
            await _rentalService.DeleteRental(id);
        }

        [HttpPut("{id}")]
        public async Task UpdateRental([FromBody] UpdateRental updateRental, int id)
        {
            await _rentalService.UpdateRental(updateRental, id);
        }

        [HttpGet("filter user")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            IEnumerable<RentalDTO> z = await _rentalService.GetByUser(userId);
            return Json(z);
        }

        [HttpGet("filter movie")]
        public async Task<IActionResult> GetByGenreId(int movieId)
        {
            IEnumerable<RentalDTO> z = await _rentalService.GetByMovie(movieId);
            return Json(z);
        }
    }
}
