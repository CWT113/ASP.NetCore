using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _07_跟踪快照
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
