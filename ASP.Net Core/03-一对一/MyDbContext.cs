using Microsoft.EntityFrameworkCore;

namespace _03_一对一
{
    class MyDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliverys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //配置连接字符串
            string connectionString = 
                "Data Source=LENOVO\\SQLSERVER;Initial Catalog=EF Core;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
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
