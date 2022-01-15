using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Core.Domain;
using VideoRental.Core.Repositories;

namespace VideoRental.Infrastructure.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        public static List<Director> _directorMock = new List<Director>();
        public DirectorRepository()
        {
            _directorMock.Add(new Director()
            {
                Id = 0,
                Name = "Quentin",
                Surname = "Tarantino",
                Description = "Quentin Jerome Tarantino is an American filmmaker, film director, screenwriter, producer, film critic, and actor. " +
                "His films are characterized by nonlinear storylines, dark humor, stylized violence, extended dialogue, ensemble casts, references to popular culture, alternate history, and neo-noir."

            });
            _directorMock.Add(new Director()
            {
                Id = 1,
                Name = "Stanley",
                Surname = "Kubrick",
                Description = "Stanley Kubrick was an American film director, producer, screenwriter, and photographer. He is frequently cited as one of the greatest filmmakers in cinematic history."

            });
        }
        public async Task AddAsync(Director director)
        {
            try
            {
                _directorMock.Add(director);
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
                return await Task.FromResult(_directorMock);
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
                _directorMock.Remove(_directorMock.Find(x => x.Id == id));
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
                return await Task.FromResult(_directorMock.Find(x => x.Id == id));
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
                var z = _directorMock.Find(x => x.Id == id);
                z.Name = director.Name;
                z.Surname = director.Surname;
                z.Description = director.Description;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }
    }
}
