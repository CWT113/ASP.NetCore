namespace _06_分页查询
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriatPage(1, 3);
            using MyDbContext ctx = new MyDbContext();

            // 1、IQueryable分批从数据库读取数据；（内存占用小，数据库连接时间长）
            IQueryable<Article> res = ctx.Articles.Where(d => d.Id > 0);

            foreach (Article item in res)
            {
                Console.WriteLine(item.Title);
                Thread.Sleep(10);
            }

            // 2、IQueryable从数据库读取所有数据，放置内容中，再进行遍历。（内存占用大，数据库连接时间短）
            var res1 = ctx.Articles.Where(d => d.Id > 0).ToArray();

            foreach (Article item in res1)
            {
                Console.WriteLine(item.Title);
                Thread.Sleep(10);
            }
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