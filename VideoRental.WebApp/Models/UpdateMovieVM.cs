using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class UpdateMovieVM
    {
        private IEnumerable<GenreVM> _genres;
        private IEnumerable<DirectorVM> _directors;
        private GenreVM _genreOld;
        private DirectorVM _directorOld;
        public UpdateMovieVM()
        {
        }
        public UpdateMovieVM(IEnumerable<GenreVM> Genres, IEnumerable<DirectorVM> Directors, GenreVM genreOld, DirectorVM directorOld)
        {
            _genres = Genres;
            _directors = Directors;
            _genreOld = genreOld;
            _directorOld = directorOld;

            _genres = _genres.Where(a => a.Id != _genreOld.Id);
            _directors = _directors.Where(a => a.Id != _directorOld.Id);

            OptionsGenres = _genres.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            OptionsGenres.Insert(0, new SelectListItem { Value = genreOld.Id.ToString(), Text = _genreOld.Name });
            OptionsDirectors = _directors.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name + " " + a.Surname }).ToList();
            OptionsDirectors.Insert(0, new SelectListItem { Value = _directorOld.Id.ToString(), Text = _directorOld.Name + " " + _directorOld.Surname });
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Genre")]
        public int IdGenre { get; set; }
        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Director")]
        public int IdDirector { get; set; }
        [DisplayName("Age restriction")]
        public int AgeRating { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        public List<SelectListItem> OptionsGenres { get; set; }
        public List<SelectListItem> OptionsDirectors { get; set; }
    }
}
