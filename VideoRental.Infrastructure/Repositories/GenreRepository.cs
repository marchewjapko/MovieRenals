using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private AppDbContext _appDbContext;
        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Genre>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Genre);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task AddAsync(Genre genre)
        {
            try
            {
                _appDbContext.Genre.Add(genre);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Genre.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Genre> GetAsync(int id)
        {
            var z = await Task.FromResult(_appDbContext.Genre.FirstOrDefault(x => x.Id == id));
            return z;
        }

        public async Task<IEnumerable<Genre>> GetByFilter(string name)
        {
            try
            {
                return await Task.FromResult(_appDbContext.Genre.Where(x => x.Name.Contains(name)));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task UpdateAsync(Genre genre, int id)
        {
            try
            {
                var z = _appDbContext.Genre.FirstOrDefault(x => x.Id == id);
                z.Name = genre.Name;
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
