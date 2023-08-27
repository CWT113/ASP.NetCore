using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreBook
{
    internal class MyDbContextDesignFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyDBContext> builder = new();
            //string? ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            string ConnectionString = "Data Source=LENOVO\\SQLSERVER;Initial Catalog=demo8;Integrated Security=SSPI;Connect Timeout=30;";
            builder.UseSqlServer(ConnectionString);
            MyDBContext ctx = new(builder.Options);
            return ctx;
        }
    }
}
