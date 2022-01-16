using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreVM Genre { get; set; }
        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; }
        public DirectorVM Director { get; set; }
        [DisplayName("Age restriction")]
        public int AgeRating { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}
