using System;
using System.Collections.Generic;
using System.Text;
using VideoRental.Infrastructure.DTO;

namespace VideoRental.Infrastructure.Commands
{
    public class CreateMovie
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
