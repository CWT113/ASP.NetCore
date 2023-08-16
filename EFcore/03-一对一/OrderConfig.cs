using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_一对一
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("T_Orders");

            //配置一对一：HasOne().WithOne().HasPrincipalKey()
            builder.HasOne<Delivery>(d => d.Delivery)
                .WithOne(d => d.Order)
                .HasPrincipalKey<Delivery>(d => d.OrderId);
        }
    }
}
