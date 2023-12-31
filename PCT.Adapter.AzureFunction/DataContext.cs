﻿using Microsoft.EntityFrameworkCore;
using PCT.Adapter.AzureFunction.Entities;


namespace PCT.Adapter.AzureFunction
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual void EnsureSeeded()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
