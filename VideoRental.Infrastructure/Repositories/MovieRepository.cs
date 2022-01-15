using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;
using VideoRental.Infrastructure.Services;
using System.Linq;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> _MovieMock = new List<Movie>();
        public MovieRepository()
        {
            _MovieMock.Add(new Movie()
            {
                Id = 0,
                Name = "Pulp Fiction",
                IdGenre = 0,
                ReleaseDate = new DateTime(1994, 5, 21),
                IdDirector = 0,
                AgeRating = 18,
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                Rating = 8.9
            });
            _MovieMock.Add(new Movie()
            {
                Id = 1,
                Name = "2001: A Space Odyssey",
                IdGenre = 1,
                ReleaseDate = new DateTime(1968, 4, 2),
                IdDirector = 1,
                AgeRating = 12,
                Description = "The Monoliths push humanity to reach for the stars; after their discovery in Africa generations ago, the mysterious objects lead mankind on an awesome journey to Jupiter, with the help of H.A.L. 9000: the world's greatest supercomputer.",
                Rating = 8.3
            });
        }
        public async Task AddAsync(Movie Movie)
        {
            try
            {
                _MovieMock.Add(Movie);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Movie>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_MovieMock);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _MovieMock.Remove(_MovieMock.Find(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Movie> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_MovieMock.Find(x => x.Id == id));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Movie>> GetByFilterDirectorId(int directorId)
        {
            try
            {
                return await Task.FromResult(_MovieMock.FindAll(x => x.IdDirector == directorId));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Movie>> GetByFilterGenreId(int genreId)
        {
            try
            {
                return await Task.FromResult(_MovieMock.FindAll(x => x.IdGenre == genreId));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task UpdateAsync(Movie movie, int id)
        {
            try
            {
                var z = _MovieMock.Find(x => x.Id == id);
                z.Name = movie.Name;
                z.IdGenre = movie.IdGenre;
                z.ReleaseDate = movie.ReleaseDate;
                z.IdDirector = movie.IdDirector;
                z.AgeRating = movie.AgeRating;
                z.Description = movie.Description;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
