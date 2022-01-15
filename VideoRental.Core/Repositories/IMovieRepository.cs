using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;

namespace VideoRental.Core.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> BrowseAllAsync();
        Task AddAsync(Movie movie);
        Task<Movie> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Movie movie, int id);
        Task<IEnumerable<Movie>> GetByFilterDirectorId(int directorId);
        Task<IEnumerable<Movie>> GetByFilterGenreId(int genreId);
    }
}