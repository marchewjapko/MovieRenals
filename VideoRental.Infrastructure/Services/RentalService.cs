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
                IdUser = createRental.IdUser,
                IdMovie = createRental.IdMovie,
                RentalDate = createRental.RentalDate
            };
            await _rentalRepository.AddAsync(z);
        }

        public async Task<IEnumerable<RentalDTO>> BrowseAll()
        {
            var z = await _rentalRepository.BrowseAllAsync();
            List<RentalDTO> rentals = new List<RentalDTO>();
            for(int i=0; i<z.Count(); i++)
            {
                rentals.Add(new RentalDTO
                {
                    Id = z.ElementAt(i).Id,
                    userDTO = _userService.GetUser(z.ElementAt(i).IdUser).Result,
                    movieDTO = _movieService.GetMovie(z.ElementAt(i).IdMovie).Result,
                    RentalDate = z.ElementAt(i).RentalDate
                });
            }
            return rentals;
        }

        public async Task DeleteRental(int id)
        {
            await _rentalRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RentalDTO>> GetByMovie(int movieId)
        {
            var z = await _rentalRepository.GetByFilterMovie(movieId);
            List<RentalDTO> rentals = new List<RentalDTO>();
            for (int i = 0; i < z.Count(); i++)
            {
                rentals.Add(new RentalDTO
                {
                    Id = z.ElementAt(i).Id,
                    userDTO = _userService.GetUser(z.ElementAt(i).IdUser).Result,
                    movieDTO = _movieService.GetMovie(z.ElementAt(i).IdMovie).Result,
                    RentalDate = z.ElementAt(i).RentalDate
                });
            }
            return rentals;
        }

        public async Task<IEnumerable<RentalDTO>> GetByUser(int userId)
        {
            var z = await _rentalRepository.GetByFilterUser(userId);
            List<RentalDTO> rentals = new List<RentalDTO>();
            for (int i = 0; i < z.Count(); i++)
            {
                rentals.Add(new RentalDTO
                {
                    Id = z.ElementAt(i).Id,
                    userDTO = _userService.GetUser(z.ElementAt(i).IdUser).Result,
                    movieDTO = _movieService.GetMovie(z.ElementAt(i).IdMovie).Result,
                    RentalDate = z.ElementAt(i).RentalDate
                });
            }
            return rentals;
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
                IdUser = updateRental.IdUser,
                IdMovie = updateRental.IdMovie,
                RentalDate = updateRental.RentalDate
            };
            await _rentalRepository.UpdateAsync(z, id);
        }
    }
}
