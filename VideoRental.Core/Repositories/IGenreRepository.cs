using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;

namespace VideoRental.Core.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> BrowseAllAsync();
        Task AddAsync(Genre genre);
        Task<Genre> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Genre genre, int id);
        Task<IEnumerable<Genre>> GetByFilter(string name);
    }
}
