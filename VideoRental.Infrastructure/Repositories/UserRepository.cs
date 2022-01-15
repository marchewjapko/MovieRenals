using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public static List<User> _UserMock = new List<User>();
        public UserRepository()
        {
            _UserMock.Add(new User()
            {
                Id = 0,
                Name = "Tom",
                Surname = "Jones"

            });
            _UserMock.Add(new User()
            {
                Id = 1,
                Name = "Marie",
                Surname = "La Valette"

            });
        }
        public async Task AddAsync(User User)
        {
            try
            {
                _UserMock.Add(User);
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
                return await Task.FromResult(_UserMock);
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
                _UserMock.Remove(_UserMock.Find(x => x.Id == id));
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
                return await Task.FromResult(_UserMock.Find(x => x.Id == id));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<User>> GetByFilter(string surname)
        {
            try
            {
                return await Task.FromResult(_UserMock.FindAll(x => x.Surname.Contains(surname)));
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
                var z = _UserMock.Find(x => x.Id == id);
                z.Name = User.Name;
                z.Surname = User.Surname;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
