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
        }
    }
}
