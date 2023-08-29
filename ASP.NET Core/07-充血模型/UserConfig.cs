using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _07_充血模型
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property("PasswordHash");//需求3
            builder.Property(d => d.Remark).HasField("remark");//需求四
            builder.Ignore(d => d.Tag);
        }
    }
}
