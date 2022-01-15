using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreService _genreService;
        private readonly IDirectorService _directorService;
        public MovieService(IMovieRepository movieRepository, IGenreService genreService, IDirectorService directorService)
        {
            _movieRepository = movieRepository;
            _genreService = genreService;
            _directorService = directorService;
        }

        public async Task AddMovie(CreateMovie createMovie)
        {
            var z = new Movie()
            {
                Id = createMovie.Id,
                Name = createMovie.Name,
                IdGenre = createMovie.IdGenre,
                ReleaseDate = createMovie.ReleaseDate,
                IdDirector = createMovie.IdDirector,
                AgeRating = createMovie.AgeRating,
                Description = createMovie.Description,
                Rating = createMovie.Rating
            };
            await _movieRepository.AddAsync(z);
        }

        public async Task<IEnumerable<MovieDTO>> BrowseAll()
        {
            var z = await _movieRepository.BrowseAllAsync();
            return z.Select(x => new MovieDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Genre = _genreService.GetGenre(x.IdGenre).Result,
                ReleaseDate = x.ReleaseDate,
                Director = _directorService.GetDirector(x.IdDirector).Result,
                AgeRating = x.AgeRating,
                Description = x.Description,
                Rating = x.Rating
            });
        }

        public async Task DeleteMovie(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MovieDTO>> GetByDirectorId(int directorId)
        {
            var z = await _movieRepository.GetByFilterDirectorId(directorId);
            return z.Select(x => new MovieDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Genre = _genreService.GetGenre(x.IdGenre).Result,
                ReleaseDate = x.ReleaseDate,
                Director = _directorService.GetDirector(x.IdDirector).Result,
                AgeRating = x.AgeRating,
                Description = x.Description,
                Rating = x.Rating
            });
        }

        public async Task<IEnumerable<MovieDTO>> GetByGenreId(int genreId)
        {
            var z = await _movieRepository.GetByFilterGenreId(genreId);
            return z.Select(x => new MovieDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Genre = _genreService.GetGenre(x.IdGenre).Result,
                ReleaseDate = x.ReleaseDate,
                Director = _directorService.GetDirector(x.IdDirector).Result,
                AgeRating = x.AgeRating,
                Description = x.Description,
                Rating = x.Rating
            });
        }

        public async Task<MovieDTO> GetMovie(int id)
        {
            var z = await _movieRepository.GetAsync(id);
            var x = new MovieDTO()
            {
                Id = z.Id,
                Name = z.Name,
                Genre = _genreService.GetGenre(z.IdGenre).Result,
                ReleaseDate = z.ReleaseDate,
                Director = _directorService.GetDirector(z.IdDirector).Result,
                AgeRating = z.AgeRating,
                Description = z.Description,
                Rating = z.Rating
            };
            return x;
        }

        public async Task UpdateMovie(UpdateMovie updateMovie, int id)
        {
            Movie z = new Movie()
            {
                Id = updateMovie.Id,
                Name = updateMovie.Name,
                IdGenre = updateMovie.IdGenre,
                ReleaseDate = updateMovie.ReleaseDate,
                IdDirector = updateMovie.IdDirector,
                AgeRating = updateMovie.AgeRating,
                Description = updateMovie.Description,
                Rating = updateMovie.Rating
            };
            await _movieRepository.UpdateAsync(z, id);
        }
    }
}
