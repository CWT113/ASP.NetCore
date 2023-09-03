using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserMsr.Domain.Entities;

namespace UserMsr.Infrastracture
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistories { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
