using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Infrastructure.Commands
{
    public class UpdateGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
