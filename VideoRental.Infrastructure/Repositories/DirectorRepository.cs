using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private AppDbContext _appDbContext;
        public DirectorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Director director)
        {
            try
            {
                _appDbContext.Director.Add(director);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Director>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Director);
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
                _appDbContext.Director.Remove(_appDbContext.Director.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Director> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Director.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task UpdateAsync(Director director, int id)
        {
            try
            {
                var z = _appDbContext.Director.FirstOrDefault(x => x.Id == id);
                z.Name = director.Name;
                z.Surname = director.Surname;
                z.Description = director.Description;
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
