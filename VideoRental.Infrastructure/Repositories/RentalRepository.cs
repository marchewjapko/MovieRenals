using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private AppDbContext _appDbContext;
        public RentalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Rental Rental)
        {
            try
            {
                _appDbContext.Rental.Add(Rental);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
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
                return await Task.FromResult(_appDbContext.Rental);
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
                _appDbContext.Remove(_appDbContext.Movie.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
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
                return await Task.FromResult(_appDbContext.Rental.FirstOrDefault(x => x.Id == id));
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
                return await Task.FromResult(_appDbContext.Rental.Where(x => x.IdUser == userId));
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
                return await Task.FromResult(_appDbContext.Rental.Where(x => x.IdMovie == movieId));
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
                var z = _appDbContext.Rental.FirstOrDefault(x => x.Id == id);
                z.IdUser = Rental.IdUser;
                z.IdMovie = Rental.IdMovie;
                z.RentalDate = Rental.RentalDate;
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
