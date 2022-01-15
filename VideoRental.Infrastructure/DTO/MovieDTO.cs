using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Infrastructure.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreDTO Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DirectorDTO Director { get; set; }
        public int AgeRating { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}
