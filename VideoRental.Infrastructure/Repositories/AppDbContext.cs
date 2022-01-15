using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoRental.Core.Domain;

namespace VideoRental.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
}
