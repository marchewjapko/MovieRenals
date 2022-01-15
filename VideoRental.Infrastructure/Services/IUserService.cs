using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> BrowseAll();
        Task AddUser(CreateUser createUser);
        Task<UserDTO> GetUser(int id);
        Task<IEnumerable<UserDTO>> GetBySurname(string surname);
        Task UpdateUser(UpdateUser updateUser, int id);
        Task DeleteUser(int id);
    }
}
