using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;
using VideoRental.Infrastructure.Services;

namespace VideoRental.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllAsync()
        {
            IEnumerable<UserDTO> z = await _UserService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            UserDTO z = await _UserService.GetUser(id);
            return Json(z);
        }

        [HttpPost]
        public async Task AddUser([FromBody] CreateUser User)
        {
            await _UserService.AddUser(User);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter(string name)
        {
            IEnumerable<UserDTO> z = await _UserService.GetByFilter(name);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateCompetitor([FromBody] UpdateUser updateUser, int id)
        {
            await _UserService.UpdateUser(updateUser, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await _UserService.DeleteUser(id);
        }
    }
}
