using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Persistence
{
    public class DevCarsDbContext : DbContext
    {
        public DevCarsDbContext(DbContextOptions<DevCarsDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ExtraOrderItem> ExtraOrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
            .HasKey(c => c.Id);
            modelBuilder.Entity<Car>()
            .ToTable("TB_CAR");
            modelBuilder.Entity<Car>()
            .Property(c => c.Brand)
            .HasMaxLength(100);
            modelBuilder.Entity<Car>()
            .Property(c => c.ProductionDate)
            .HasDefaultValueSql("GETDATE()");
 
            modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
            modelBuilder.Entity<Customer>()
            .ToTable("TB_CUSTOMER");

            modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);
            modelBuilder.Entity<Order>()
            .ToTable("TB_ORDER");

            modelBuilder.Entity<ExtraOrderItem>()
            .HasKey(e => e.Id);
            modelBuilder.Entity<ExtraOrderItem>()
            .ToTable("TB_EXTRA_ORDER_ITEM")
        }
    }
}