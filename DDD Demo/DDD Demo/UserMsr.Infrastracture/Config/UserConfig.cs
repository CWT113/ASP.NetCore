using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMsr.Domain.Entities;

namespace UserMsr.Infrastracture.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.OwnsOne(d => d.PhoneNumber, nb =>
            {
                nb.Property(d => d.Number)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            builder.HasOne(d => d.UserAccessFail)
                .WithOne(d => d.User)
                .HasForeignKey<UserAccessFail>(d => d.UserId);
            builder.Property("PasswosrdHash").HasMaxLength(100).IsUnicode(false);
        }
    }
}
