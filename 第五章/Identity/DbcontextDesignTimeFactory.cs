using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity;

public class DbcontextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbcontext>
{
    public MyDbcontext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<MyDbcontext> builder = new DbContextOptionsBuilder<MyDbcontext>();
        builder.UseSqlServer("Data Source=LENOVO\\SQLSERVER;Initial Catalog=Identity Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        return new MyDbcontext(builder.Options);
    }
}
