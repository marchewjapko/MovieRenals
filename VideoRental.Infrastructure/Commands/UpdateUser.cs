using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Infrastructure.Commands
{
    public class UpdateUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
