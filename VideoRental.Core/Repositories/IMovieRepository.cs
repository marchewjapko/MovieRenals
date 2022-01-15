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
        Task<Genre> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Movie movie);
        Task<IEnumerable<Movie>> GetByFilterGenre(int genreId);
        Task<IEnumerable<Movie>> GetByFilterDirector(int directorId);
    }
}
