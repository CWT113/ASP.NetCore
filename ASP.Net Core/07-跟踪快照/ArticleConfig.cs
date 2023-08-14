using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _07_跟踪快照
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //输出为那张表
            builder.ToTable("T_Articles");
            //设置字段在数据库中的属性
            builder.Property(x => x.Title).HasMaxLength(100).IsUnicode().IsRequired();
            builder.Property(x => x.Message).IsUnicode().IsRequired();
        }
    }
}
