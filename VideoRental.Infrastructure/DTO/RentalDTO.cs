using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Infrastructure.DTO
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public UserDTO userDTO { get; set; }
        public MovieDTO movieDTO { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
