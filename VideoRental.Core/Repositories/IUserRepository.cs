using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;

namespace VideoRental.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> BrowseAllAsync();
        Task AddAsync(User user);
        Task<User> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(User User, int id);
        Task<IEnumerable<User>> GetByFilter(string s);
    }
}
