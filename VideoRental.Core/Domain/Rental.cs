﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Core.Domain
{
    public class Rental
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMovie { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
