using Apple1_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class Apple1DbContext : DbContext
    {
        public Apple1DbContext(DbContextOptions<Apple1DbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRef).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Screen> Covers { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Charger> Chargers { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<HeadPhone> HeadPhones { get; set; }
        public DbSet<Others> Others { get; set; }
        public DbSet<DailySales> dailySales { get; set; }
        public DbSet<DailySalesArchive> dailySalesArchives { get; set; }

        public DbSet<Sale> Sales { get; set; }








    }
}
