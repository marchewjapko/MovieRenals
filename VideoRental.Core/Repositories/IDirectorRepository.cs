using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;

namespace VideoRental.Core.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> BrowseAllAsync();
        Task AddAsync(Director director);
        Task<Director> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Director director, int id);
    }
}
