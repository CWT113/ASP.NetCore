using Microsoft.EntityFrameworkCore;

namespace ActionFilter;

public class MyDBContext : DbContext
{
    public DbSet<Book> books { get; set; }
    public DbSet<Person> people { get; set; }

    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
    {
    }
}
