using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutipSmart.Models;
using Microsoft.EntityFrameworkCore;
using KutipSmart.Models;
using Route = KutipSmart.Models.Route;



namespace KutipSmart.Data
{
    public class KutipDbContext : DbContext
    {

        public KutipDbContext(DbContextOptions<KutipDbContext> options) : base(options)
        {
        }

        
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<Bin> RouteStops { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Trucks
            modelBuilder.Entity<Truck>().HasData(
                new Truck { Id = 1, TruckNo = "TRK-001", DriverName = "Ali Rahman", Status = TruckStatus.Active },
                new Truck { Id = 2, TruckNo = "TRK-002", DriverName = "Ahmad Yusuf", Status = TruckStatus.Inactive }

            );

            // Seed Routes
            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, TruckId = 1, ScheduledDate = DateTime.UtcNow.Date }
            );

            // Seed Route Stops
            modelBuilder.Entity<Bin>().HasData(
                new Bin { Id = 1, RouteId = 1, Latitude = 1.3521, Longitude = 103.8198, Address = "Bin A", Order = 1 },
                new Bin { Id = 2, RouteId = 1, Latitude = 1.3648, Longitude = 103.8219, Address = "Bin B", Order = 2 }
            );
        }

    }
}
