using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> BrowseAll();
        Task AddGenre(CreateGenre createGenre);
        Task<GenreDTO> GetGenre(int id);
        Task<IEnumerable<GenreDTO>> GetByName(string name);
        Task UpdateGenre(UpdateGenre updateGenre, int id);
        Task DeleteGenre(int id);
    }
}
