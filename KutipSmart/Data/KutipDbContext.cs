﻿using System;
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


        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Bin> Bin { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Notification> Notifications { get; set; }




    }
}
