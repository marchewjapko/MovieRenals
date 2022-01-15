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
    public class MovieController : Controller
    {
        private readonly IMovieService _MovieService;

        public MovieController(IMovieService MovieService)
        {
            _MovieService = MovieService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllAsync()
        {
            IEnumerable<MovieDTO> z = await _MovieService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            MovieDTO z = await _MovieService.GetMovie(id);
            return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMovie(int id)
        {
            await _MovieService.DeleteMovie(id);
        }

        [HttpPost]
        public async Task AddMovie([FromBody] CreateMovie genre)
        {
            await _MovieService.AddMovie(genre);     
        }

        [HttpGet("filter director")]
        public async Task<IActionResult> GetByDirectorId(int directorId)
        {
            IEnumerable<MovieDTO> z = await _MovieService.GetByDirectorId(directorId);
            return Json(z);
        }

        [HttpGet("filter genre")]
        public async Task<IActionResult> GetByGenreId(int genreId)
        {
            IEnumerable<MovieDTO> z = await _MovieService.GetByDirectorId(genreId);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateMovie([FromBody] UpdateMovie updateMovie, int id)
        {
            await _MovieService.UpdateMovie(updateMovie, id);
        }
    }
}
