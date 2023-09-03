using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserMsr.Domain.Entities;

namespace UserMsr.Infrastracture.Config
{
    public class UserLoginHistoryConfig : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.ToTable("T_UserLoginHistory");
            builder.OwnsOne(d => d.PhoneNumber, nb =>
            {
                nb.Property(d => d.Number)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
