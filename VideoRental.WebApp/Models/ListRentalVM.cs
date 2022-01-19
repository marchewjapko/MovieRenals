using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class ListRentalVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public MovieVM movieDTO { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
