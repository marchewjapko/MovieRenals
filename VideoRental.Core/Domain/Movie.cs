using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Core.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Director Director { get; set; }
        public int AgeRating { get; set; }
        public string Description { get; set; }
    }
}
