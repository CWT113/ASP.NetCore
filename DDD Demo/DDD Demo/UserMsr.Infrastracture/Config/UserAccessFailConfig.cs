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
    public class UserAccessFailConfig : IEntityTypeConfiguration<UserAccessFail>
    {
        public void Configure(EntityTypeBuilder<UserAccessFail> builder)
        {
            builder.ToTable("T_UserAccessFail");
            builder.Property("IsLockOut1");
        }
    }
}
