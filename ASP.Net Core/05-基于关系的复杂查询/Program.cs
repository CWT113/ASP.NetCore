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
            //IQueryable<Comment> result = ctx.Comments;
            //IQueryable<Comment> res = result.Where(d => d.Message.Contains("微软"));
            //// sql语句：SELECT [t].[Id], [t].[ArticleId], [t].[Message] FROM[T_Comment] AS[t] WHERE[t].[Message] LIKE N'%微软%'
            //foreach (Comment item in res)
            //{
            //    Console.WriteLine(item.Message);
            //}

            //// 2、客户端评估（即在内存中比对，效率较低）
            //IEnumerable<Comment> result = ctx.Comments;
            //IEnumerable<Comment> res = result.Where(d => d.Message.Contains("微软"));
            //// sql语句：SELECT [t].[Id], [t].[ArticleId], [t].[Message] FROM[T_Comment] AS[t]
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Message);
            //}
            #endregion

            #region IQueryable的延迟执行
            // 1、IQueryable只在终结方法之后，才会被执行
            //    终结方法：遍历、ToArray()、ToList()、Min()、Max()、Count()  --> 返回值不为IQueryable类型
            //    非终结方法：GroupBy()、OrderBy()、Skip()、Take()  --> 返回值仍为IQueryable类型
            //Console.WriteLine("---------------------sql语句执行之前---------------------");
            //var res = ctx.Articles.Where(d => d.Title.Contains("微软"));
            //Console.WriteLine("---------------------sql语句执行之后！！---------------------");

            //foreach (Article item in res)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //res.OrderBy(d => d.Id);
            //res.GroupBy(d => d.Title);

            //res.ToList();
            //res.ToArray();
            #endregion

            #region IQueryable延迟执行的示例
            //IQueryable<Article> res = ctx.Articles.Where(d => d.Id > 1);
            //IQueryable<Article> res1 = res.Skip(1);
            //IQueryable<Article> res2 = res1.Take(2);
            //IQueryable<Article> res3 = res2.Where(d => d.Message.Contains("微软"));
            //res2.ToArray();

            //IQueryable<Article> result = ctx.Articles.Where(d => d.Id > 1 && d.Message.Contains("微软")).Skip(1).Take(3);
            //result.ToArray();
            #endregion

            #region IQueryable的分部查询
            //IQueryAbles("微软", true, true, 50);
            #endregion
        }

        /// <summary>
        /// 分部式查询
        /// </summary>
        /// <param name="str">查询字符串</param>
        /// <param name="searchAll">是否查询所有</param>
        /// <param name="orderByPrice">是否按照价格排序</param>
        /// <param name="UpperPrice">价格上限</param>
        private static void IQueryAbles(string str, bool searchAll, bool orderByPrice, double UpperPrice)
        {
            using MyDbContext ctx = new MyDbContext();
            IQueryable<Article> res = ctx.Articles.Where(d => d.Price <= UpperPrice);
            if (searchAll)
            {
                res = res.Where(d => d.Title.Contains(str) && d.Message.Contains(str));
            }
            else
            {
                res = res.Where(d => d.Title.Contains(str));
            }

            if (orderByPrice)
            {
                res = res.OrderBy(d => d.Price);
            }

            foreach (var item in res)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}