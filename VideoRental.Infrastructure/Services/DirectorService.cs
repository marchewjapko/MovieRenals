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
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _DirectorRepository;
        public DirectorService(IDirectorRepository DirectorRepository)
        {
            _DirectorRepository = DirectorRepository;
        }
        public async Task<IEnumerable<DirectorDTO>> BrowseAll()
        {
            var z = await _DirectorRepository.BrowseAllAsync();
            return z.Select(x => new DirectorDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Description = x.Description
            });
        }
        public async Task AddDirector(CreateDirector createDirector)
        {
            var z = new Director()
            {
                Name = createDirector.Name,
                Surname = createDirector.Surname,
                Description = createDirector.Description
            };
            await _DirectorRepository.AddAsync(z);
        }
        public async Task<DirectorDTO> GetDirector(int id)
        {
            var z = await _DirectorRepository.GetAsync(id);
            var x = new DirectorDTO()
            {
                Id = z.Id,
                Name = z.Name,
                Surname = z.Surname,
                Description = z.Description
            };
            return x;
        }

        public async Task UpdateDirector(UpdateDirector updateDirector, int id)
        {
            Director z = new Director()
            {
                Name = updateDirector.Name,
                Surname = updateDirector.Surname,
                Description = updateDirector.Description
            };
            await _DirectorRepository.UpdateAsync(z, id);
        }

        public async Task DeleteDirector(int id)
        {
            await _DirectorRepository.DeleteAsync(id);
        }
    }
}
