﻿using CarShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext()
       {
       }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Issue> Issues { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; User Id=sa; Password=@Test123456; Database=CarShop;");
            }
        }
    }
}
