using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class AddMovieVM
    {
        private IEnumerable<GenreVM> _genres;
        private IEnumerable<DirectorVM> _directors;
        public AddMovieVM()
        {
        }
        public AddMovieVM(IEnumerable<GenreVM> Genres, IEnumerable<DirectorVM> Directors)
        {
            _genres = Genres;
            _directors = Directors;
            OptionsGenres = _genres.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            OptionsDirectors = _directors.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name + " " + a.Surname }).ToList();
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
