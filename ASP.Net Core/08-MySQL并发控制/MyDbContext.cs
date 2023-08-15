using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _08_MySQL并发控制
{
    public class MyDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //MySql的连接字符串
            string connectionString = "server=localhost;user=root;password=1234;database=test";
            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            optionsBuilder.UseMySql(connectionString, serverVersion);
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
