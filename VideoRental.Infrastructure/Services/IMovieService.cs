using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Infrastructure.Commands;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> BrowseAll();
        Task<MovieDTO> GetMovie(int id);
        Task DeleteMovie(int id);
        Task AddMovie(CreateMovie createMovie);
        Task<IEnumerable<MovieDTO>> GetByDirectorId (int directorId);
        Task<IEnumerable<MovieDTO>> GetByGenreId(int genreId);
        Task UpdateMovie(UpdateMovie updateMovie, int id);
    }
}
