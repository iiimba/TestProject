﻿using Microsoft.EntityFrameworkCore;

namespace DataApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
