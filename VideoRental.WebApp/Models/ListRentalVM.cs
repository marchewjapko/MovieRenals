using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class ListRentalVM
    {
        public int Id { get; set; }
        [DisplayName("User")]
        public string Username { get; set; }
        [DisplayName("Movie")]
        public MovieVM movieDTO { get; set; }
        [DisplayName("Rental date")]
        public DateTime RentalDate { get; set; }
    }
}
