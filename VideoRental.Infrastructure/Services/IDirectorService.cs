using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Services
{
    public interface IDirectorService
    {
        Task<IEnumerable<DirectorDTO>> BrowseAll();
        Task AddDirector(CreateDirector createDirector);
        Task<DirectorDTO> GetDirector(int id);
        Task UpdateDirector(UpdateDirector updateDirector, int id);
        Task DeleteDirector(int id);
    }
}
