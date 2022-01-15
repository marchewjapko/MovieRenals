using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using VideoRental.Infrastructure.Services;
using VideoRental.Infrastructure.Commands;
using VideoRental.Core.Repositories;
using VideoRental.Infrastructure.DTO;
using VideoRental.Core.Domain;

namespace VideoGenre.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<GenreDTO>> BrowseAll()
        {
            var z = await _genreRepository.BrowseAllAsync();
            return z.Select(x => new GenreDTO()
            {
                Id = x.Id,
                Name = x.Name
            });
        }
        public async Task AddGenre(CreateGenre createGenre)
        {
            var z = new Genre()
            {
                Name = createGenre.Name
            };
            await _genreRepository.AddAsync(z);
        }
        public async Task<GenreDTO> GetGenre(int id)
        {
            var z = await _genreRepository.GetAsync(id);
            var x = new GenreDTO()
            {
                Id = z.Id,
                Name = z.Name
            };
            return x;
        }

        public async Task<IEnumerable<GenreDTO>> GetByName(string name)
        {
            var z = await _genreRepository.GetByFilter(name);
            return z.Select(x => new GenreDTO()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task UpdateGenre(UpdateGenre updateGenre, int id)
        {
            Genre z = new Genre()
            {
                Name = updateGenre.Name
            };
            await _genreRepository.UpdateAsync(z, id);
        }

        public async Task DeleteGenre(int id)
        {
            await _genreRepository.DeleteAsync(id);
        }
    }
}
