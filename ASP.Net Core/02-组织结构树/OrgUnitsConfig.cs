using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_组织结构树
{
    public class OrgUnitsConfig : IEntityTypeConfiguration<OrgUnits>
    {
        public void Configure(EntityTypeBuilder<OrgUnits> builder)
        {
            builder.ToTable("T_OrgUnits");
            builder.Property(x => x.Name).IsUnicode().IsRequired();
            //因为OrgUnits可能会没有父节点，所以不可设置为“不可为空”
            builder.HasOne<OrgUnits>(x => x.Parents).WithMany(x => x.Childrens);
        }
    }
}
