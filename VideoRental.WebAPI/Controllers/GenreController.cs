using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;
using VideoRental.Infrastructure.Services;

namespace VideoRental.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllAsync()
        {
            IEnumerable<GenreDTO> z = await _genreService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            GenreDTO z = await _genreService.GetGenre(id);
            return Json(z);
        }

        [HttpPost]
        public async Task AddGenre([FromBody] CreateGenre genre)
        {
            await _genreService.AddGenre(genre);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter(string name)
        {
            IEnumerable<GenreDTO> z = await _genreService.GetByName(name);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateCompetitor([FromBody] UpdateGenre updateGenre, int id)
        {
            await _genreService.UpdateGenre(updateGenre, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteGenre(int id)
        {
            await _genreService.DeleteGenre(id);
        }
    }
}
