using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;

namespace VideoRental.Core.Repositories
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> BrowseAllAsync();
        Task AddAsync(Rental movie);
        Task<Genre> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Movie movie);
        Task<IEnumerable<Movie>> GetByFilterUser(int userId);
        Task<IEnumerable<Movie>> GetByFilterMovie(int movieId);
    }
}
