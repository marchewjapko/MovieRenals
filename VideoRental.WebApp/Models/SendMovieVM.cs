using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class SendMovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdGenre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int IdDirector { get; set; }
        public int AgeRating { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}
