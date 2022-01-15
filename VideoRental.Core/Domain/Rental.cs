using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Core.Domain
{
    public class Rental
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
