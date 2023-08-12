using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _05_基于关系的复杂查询
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //输出为哪张表
            builder.ToTable("T_Comment");
            //设置字段在数据库中的属性
            builder.Property(x => x.Message).IsUnicode().IsRequired();

            //设置 一对多 的关系
            builder
                .HasOne<Article>(x => x.Article)
                .WithMany(y => y.comments).IsRequired();
        }
    }
}
