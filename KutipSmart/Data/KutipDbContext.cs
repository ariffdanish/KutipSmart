using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutipSmart.Models;
using Microsoft.EntityFrameworkCore;




namespace KutipSmart.Data
{
    public class KutipDbContext : DbContext
    {

        public KutipDbContext(DbContextOptions<KutipDbContext> options) : base(options)
        {
        }

        
<<<<<<< HEAD
        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Bin> RouteStops { get; set; } = null!;

=======
        public DbSet<Truck> Trucks { get; set; }
        
        public DbSet<Bin> Bin { get; set; }
        
>>>>>>> 69f0555792b1d5161fd9d042ab4f9efb84dc8abb

    }
}
