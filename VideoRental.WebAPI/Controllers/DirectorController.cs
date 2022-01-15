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
    public class DirectorController : Controller
    {
        private readonly IDirectorService _DirectorService;

        public DirectorController(IDirectorService DirectorService)
        {
            _DirectorService = DirectorService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllAsync()
        {
            IEnumerable<DirectorDTO> z = await _DirectorService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirector(int id)
        {
            DirectorDTO z = await _DirectorService.GetDirector(id);
            return Json(z);
        }

        [HttpPost]
        public async Task AddDirector([FromBody] CreateDirector Director)
        {
            await _DirectorService.AddDirector(Director);
        }

        [HttpPut("{id}")]
        public async Task UpdateCompetitor([FromBody] UpdateDirector updateDirector, int id)
        {
            await _DirectorService.UpdateDirector(updateDirector, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDirector(int id)
        {
            await _DirectorService.DeleteDirector(id);
        }
    }
}
