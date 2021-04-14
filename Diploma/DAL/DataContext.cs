﻿using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Diploma.DAL
{
    class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet <UserData> userDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(k => k.userId);
            modelBuilder.Entity<UserData>().HasKey(k => k.recordId);
            modelBuilder.Entity<User>().HasMany(ud => ud.UserDatas).WithOne(u => u.user).HasForeignKey(pt => pt.userId);
            modelBuilder.Entity<UserData>().HasIndex(u => new { u.name }).IsUnique();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
