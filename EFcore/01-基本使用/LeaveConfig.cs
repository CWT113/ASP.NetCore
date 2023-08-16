using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_基本使用
{
    class LeaveConfig : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable("T_Leaves");
            //离开表指向用户表
            builder.HasOne(x => x.Applicant).WithMany().IsRequired();
            builder.HasOne(x => x.Approver).WithMany();
        }
    }
}
