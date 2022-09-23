using MVC_GIT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_GIT.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EFContext")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Customer>()
                .ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(c => c.Firstname).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.MiddleName).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasMaxLength(64);
            modelBuilder.Entity<Customer>().Property(c => c.Gender).HasMaxLength(10);

            modelBuilder.Entity<Order>()
               .ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Order>().Property(c => c.No).HasMaxLength(10);
            modelBuilder.Entity<Order>().Property(c => c.OrderName).HasMaxLength(64);
            modelBuilder.Entity<Order>().Property(c => c.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Order>()
                 .HasRequired(c => c.Customer)
                 .WithMany()
                 .HasForeignKey(d => d.CustomerId);
        }

    }
}