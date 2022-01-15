using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Services
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> BrowseAll();
        Task<RentalDTO> GetRental(int id);
        Task AddRental(CreateRental createRental);
        Task DeleteRental(int id);
        Task UpdateRental(UpdateRental updateRental, int id);
        Task<IEnumerable<RentalDTO>> GetByUser(int userId);
        Task<IEnumerable<RentalDTO>> GetByMovie(int movieId);
    }
}
