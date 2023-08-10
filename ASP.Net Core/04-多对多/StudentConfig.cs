using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_多对多
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("T_Students");
            builder.HasMany<Teacher>(d => d.Teachers)
                .WithMany(d => d.Students)
                .UsingEntity(d => d.ToTable("T_Students_Teachers"));
        }
    }
}
