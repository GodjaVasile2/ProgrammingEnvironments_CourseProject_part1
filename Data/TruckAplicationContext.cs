using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TruckAplication.Models;

namespace TruckAplication.Data
{
    public class TruckAplicationContext : DbContext
    {
        public TruckAplicationContext (DbContextOptions<TruckAplicationContext> options)
            : base(options)
        {
        }

        public DbSet<TruckAplication.Models.Truck> Truck { get; set; } = default!;

        public DbSet<TruckAplication.Models.Driver> Driver { get; set; }

        public DbSet<TruckAplication.Models.Category> Category { get; set; }

        public DbSet<TruckAplication.Models.Client> Client { get; set; }

        public DbSet<TruckAplication.Models.Request> Request { get; set; }
    }
}
