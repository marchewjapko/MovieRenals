using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(User User)
        {
            try
            {
                _appDbContext.User.Add(User);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<User>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.User);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.User.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.User.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<User>> GetByFilter(string s)
        {
            try
            {
                return await Task.FromResult(_appDbContext.User.Where(x => (x.Surname.Contains(s) || x.Name.Contains(s))));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task UpdateAsync(User User, int id)
        {
            try
            {
                var z = _appDbContext.User.FirstOrDefault(x => x.Id == id);
                z.Name = User.Name;
                z.Surname = User.Surname;
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
