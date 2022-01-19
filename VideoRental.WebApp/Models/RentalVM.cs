using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.WebApp.Models
{
    public class RentalVM
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public MovieVM movieDTO { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
