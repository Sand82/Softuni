﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=localhost; User Id=sa;Password=@Stefanov820605; Database=CodeFirstDemo");
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Comment> Comments { get; set; }

        
    }
}
