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
    public class RentalService : IRentalService
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository, IUserService userService, IMovieService movieService)
        {
            _movieService = movieService;
            _userService = userService;
            _rentalRepository = rentalRepository;
        }

        public async Task AddRental(CreateRental createRental)
        {
            var z = new Rental()
            {
                Id = createRental.Id,
                IdUser = createRental.IdUser,
                IdMovie = createRental.IdMovie,
                RentalDate = createRental.RentalDate
            };
            await _rentalRepository.AddAsync(z);
        }

        public async Task<IEnumerable<RentalDTO>> BrowseAll()
        {
            var z = await _rentalRepository.BrowseAllAsync();
            return z.Select(x => new RentalDTO()
            {
                Id = x.Id,
                userDTO = _userService.GetUser(x.IdUser).Result,
                movieDTO = _movieService.GetMovie(x.IdMovie).Result,
                RentalDate = x.RentalDate
            });
        }

        public async Task DeleteRental(int id)
        {
            await _rentalRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RentalDTO>> GetByMovie(int movieId)
        {
            var z = await _rentalRepository.GetByFilterMovie(movieId);
            return z.Select(x => new RentalDTO()
            {
                Id = x.Id,
                userDTO = _userService.GetUser(x.IdUser).Result,
                movieDTO = _movieService.GetMovie(x.IdMovie).Result,
                RentalDate = x.RentalDate
            });
        }

        public async Task<IEnumerable<RentalDTO>> GetByUser(int userId)
        {
            var z = await _rentalRepository.GetByFilterUser(userId);
            return z.Select(x => new RentalDTO()
            {
                Id = x.Id,
                userDTO = _userService.GetUser(x.IdUser).Result,
                movieDTO = _movieService.GetMovie(x.IdMovie).Result,
                RentalDate = x.RentalDate
            });
        }

        public async Task<RentalDTO> GetRental(int id)
        {
            var z = await _rentalRepository.GetAsync(id);
            var x = new RentalDTO()
            {
                Id = z.Id,
                userDTO = _userService.GetUser(z.IdUser).Result,
                movieDTO = _movieService.GetMovie(z.IdMovie).Result,
                RentalDate = z.RentalDate
            };
            return x;
        }

        public async Task UpdateRental(UpdateRental updateRental, int id)
        {
            var z = new Rental()
            {
                Id = updateRental.Id,
                IdUser = updateRental.IdUser,
                IdMovie = updateRental.IdMovie,
                RentalDate = updateRental.RentalDate
            };
            await _rentalRepository.UpdateAsync(z, id);
        }
    }
}
