using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _08_MySQL并发控制
{
    public class HouseConfig : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable("T_Houses");
            builder.Property(d => d.Name).IsRequired();
            //设置乐观并发控制令牌
            //builder.Property(d => d.Owner).IsConcurrencyToken();

            //多乐观并发控制
            builder.Property(d => d.RowVersion).IsRowVersion();
        }
    }
}
