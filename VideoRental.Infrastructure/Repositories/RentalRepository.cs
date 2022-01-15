using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        public static List<Rental> _RentalMock = new List<Rental>();
        public RentalRepository()
        {
            _RentalMock.Add(new Rental()
            {
                Id = 0,
                IdUser = 0,
                IdMovie = 0,
                RentalDate = new DateTime(2020, 1, 1)
            });
            _RentalMock.Add(new Rental()
            {
                Id = 1,
                IdUser = 1,
                IdMovie = 1,
                RentalDate = new DateTime(2020, 1, 1)
            });
        }
        public async Task AddAsync(Rental Rental)
        {
            try
            {
                _RentalMock.Add(Rental);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Rental>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_RentalMock);
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
                _RentalMock.Remove(_RentalMock.Find(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Rental> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_RentalMock.Find(x => x.Id == id));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Rental>> GetByFilterUser(int userId)
        {
            try
            {
                return await Task.FromResult(_RentalMock.FindAll(x => x.IdUser == userId));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Rental>> GetByFilterMovie(int movieId)
        {
            try
            {
                return await Task.FromResult(_RentalMock.FindAll(x => x.IdMovie == movieId));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task UpdateAsync(Rental Rental, int id)
        {
            try
            {
                var z = _RentalMock.Find(x => x.Id == id);
                z.IdUser = Rental.IdUser;
                z.IdMovie = Rental.IdMovie;
                z.RentalDate = Rental.RentalDate;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
