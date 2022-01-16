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
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async Task<IEnumerable<UserDTO>> BrowseAll()
        {
            var z = await _UserRepository.BrowseAllAsync();
            return z.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            });
        }
        public async Task AddUser(CreateUser createUser)
        {
            var z = new User()
            {
                Name = createUser.Name,
                Surname = createUser.Surname
            };
            await _UserRepository.AddAsync(z);
        }
        public async Task<UserDTO> GetUser(int id)
        {
            var z = await _UserRepository.GetAsync(id);
            var x = new UserDTO()
            {
                Id = z.Id,
                Name = z.Name,
                Surname = z.Surname
            };
            return x;
        }

        public async Task<IEnumerable<UserDTO>> GetByFilter(string s)
        {
            var z = await _UserRepository.GetByFilter(s);
            return z.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            });
        }

        public async Task UpdateUser(UpdateUser updateUser, int id)
        {
            User z = new User()
            {
                Name = updateUser.Name,
                Surname = updateUser.Surname
            };
            await _UserRepository.UpdateAsync(z, id);
        }

        public async Task DeleteUser(int id)
        {
            await _UserRepository.DeleteAsync(id);
        }
    }
}
