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
        }
    }
}