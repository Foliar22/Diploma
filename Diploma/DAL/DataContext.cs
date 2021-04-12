using Diploma.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DAL
{
    class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet <UserData> userDatas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(k => k.userId);
            modelBuilder.Entity<UserData>().HasKey(k => k.recordId);
            modelBuilder.Entity<User>().HasMany(ud => ud.UserDatas).WithOptional(u => u.user).HasForeignKey(pt => pt.userId);

        }
        public DataContext() : base("DbConnection")
        {}

    }
}
