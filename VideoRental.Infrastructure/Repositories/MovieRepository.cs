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
        private AppDbContext _appDbContext;
        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Movie Movie)
        {
            try
            {
                _appDbContext.Movie.Add(Movie);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
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
                return await Task.FromResult(_appDbContext.Movie);
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
                _appDbContext.Movie.Remove(_appDbContext.Movie.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
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
                return await Task.FromResult(_appDbContext.Movie.FirstOrDefault(x => x.Id == id));
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
                return await Task.FromResult(_appDbContext.Movie.Where(x => x.IdDirector == directorId));
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
                return await Task.FromResult(_appDbContext.Movie.Where(x => x.IdGenre == genreId));
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
                var z = _appDbContext.Movie.FirstOrDefault(x => x.Id == id);
                z.Name = movie.Name;
                z.IdGenre = movie.IdGenre;
                z.ReleaseDate = movie.ReleaseDate;
                z.IdDirector = movie.IdDirector;
                z.AgeRating = movie.AgeRating;
                z.Description = movie.Description;
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
