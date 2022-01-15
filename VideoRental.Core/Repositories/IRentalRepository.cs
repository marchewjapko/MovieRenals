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
        Task AddAsync(Rental rental);
        Task<Rental> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Rental rental, int id);
        Task<IEnumerable<Rental>> GetByFilterUser(int userId);
        Task<IEnumerable<Rental>> GetByFilterMovie(int movieId);
    }
}
