using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using ECommerce.Models.Entities;
//using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
             : base("DefaultConnection")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // no duplicate config for Product
        }

    }
}