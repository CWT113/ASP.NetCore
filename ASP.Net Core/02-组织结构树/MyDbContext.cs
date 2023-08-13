using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_组织结构树;
using Microsoft.EntityFrameworkCore;

namespace _01_基本使用
{
    class MyDbContext : DbContext
    {
        public DbSet<OrgUnits> OrgUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //配置连接字符串
            //修复问题：MultipleActiveResultSets=true; 让ADO.NET Core 支持多个 DateRender
            string connectionString = 
                "Data Source=LENOVO\\SQLSERVER;Initial Catalog=EF Core;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connectionString);

            //打印日志
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
