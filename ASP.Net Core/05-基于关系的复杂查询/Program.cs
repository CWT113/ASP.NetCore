using System.Xml.Linq;

namespace _05_基于关系的复杂查询
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyDbContext ctx = new MyDbContext();

            // 1、通过文章 -> 查评论中含有“微软”字眼的文章
            //var res = ctx.Articles.Where(d => d.comments.Any(x => x.Message.Contains("微软")));
            //foreach (Article item in res)
            //{
            //    Console.WriteLine(item.Title);
            //}

            // 2、通过评论 -> 查评论中含有“微软”字眼的文章
            // Distinct()：去重
            //var res = ctx.Comments.Where(d => d.Message.Contains("微软")).Select(x => x.Article).Distinct();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Title);
            //}

            #region 既生IEnumerable，何生亮IQueryable
            // 1、服务端评估（即在数据库中比对，效率更高）
            IQueryable<Comment> result = ctx.Comments;
            IQueryable<Comment> res = result.Where(d => d.Message.Contains("微软"));
            // sql语句：SELECT [t].[Id], [t].[ArticleId], [t].[Message] FROM[T_Comment] AS[t] WHERE[t].[Message] LIKE N'%微软%'
            foreach (Comment item in res)
            {
                Console.WriteLine(item.Message);
            }

            //// 2、客户端评估（即在内存中比对，效率较低）
            //IEnumerable<Comment> result = ctx.Comments;
            //IEnumerable<Comment> res = result.Where(d => d.Message.Contains("微软"));
            //// sql语句：SELECT [t].[Id], [t].[ArticleId], [t].[Message] FROM[T_Comment] AS[t]
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Message);
            //}
            #endregion
        }
    }
}