namespace _06_分页查询
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriatPage(1, 3);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        private static void PriatPage(int pageIndex, int pageSize)
        {
            using MyDbContext ctx = new MyDbContext();
            //查询所有符合条件的内容
            IQueryable<Article> res = ctx.Articles.Where(d => d.Id > 0);
            //分页查询（注意：这里不要链式调用，链式调用无法计算总条数和总页数）
            IQueryable<Article> items = res.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            foreach (Article item in items)
            {
                Console.WriteLine(item.Title);
            }
            //查询总条数
            long total = res.LongCount();
            //查询总页数
            long pageTotal = (long)Math.Ceiling(total * 1.0 / pageSize);
            Console.WriteLine("总条数: " + total);
            Console.WriteLine("总页数: " + pageTotal);
        }
    }
}