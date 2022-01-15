using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public static List<Genre> _genreMock = new List<Genre>();
        public GenreRepository()
        {
            _genreMock.Add(new Genre()
            {
                Id = 0,
                Name = "Crime"
            });
            _genreMock.Add(new Genre()
            {
                Id = 1,
                Name = "Sci-Fi"
            });
        }
        public async Task AddAsync(Genre genre)
        {
            try
            {
                _genreMock.Add(genre);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Genre>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_genreMock);
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
                _genreMock.Remove(_genreMock.Find(x => x.Id == id));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Genre> GetAsync(int id)
        {
            return await Task.FromResult(_genreMock.Find(x => x.Id == id));
        }

        public async Task<IEnumerable<Genre>> GetByFilter(string name)
        {
            try
            {
                return await Task.FromResult(_genreMock.FindAll(x => x.Name.Contains(name)));
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
                var z = _genreMock.Find(x => x.Id == id);
                z.Name = genre.Name;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
