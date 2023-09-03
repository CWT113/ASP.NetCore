using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UserMsr.Infrastracture
{
    public class DBContextFactory : IDesignTimeDbContextFactory<UserDBContext>
    {
        public UserDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<UserDBContext> builder = new DbContextOptionsBuilder<UserDBContext>();
            builder.UseSqlServer("Data Source=LENOVO\\SQLSERVER;Initial Catalog=DDD Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new UserDBContext(builder.Options);
        }
    }
}
