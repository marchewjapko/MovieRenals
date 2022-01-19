using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Infrastructure.Commands
{
    public class UpdateRental
    {
        public string IdUser { get; set; }
        public int IdMovie { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
