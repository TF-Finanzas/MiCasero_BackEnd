using MiCasero_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MiCasero_WebAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Owner> Owner { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                        .HasMany(b => b.Customers)
                        .WithOne(t => t.Owner)
                        .HasForeignKey(t => t.OwnerId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Customer>()
                        .HasMany(b => b.Bills)
                        .WithOne(t => t.Customer)
                        .HasForeignKey(t => t.CustomerId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Bill>()
                        .HasMany(b => b.Transfers)
                        .WithOne(t => t.Bill)
                        .HasForeignKey(t => t.BillId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}