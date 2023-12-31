﻿using System.Data.Common;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace _06_分页查询
{
    internal class Program
    {
        /// <summary>
        /// 执行任何纯原生的sql语句
        /// </summary>
        static async Task Main(string[] args)
        {
            #region 直接通过ADO.NET执行原生sql语句
            //using MyDbContext ctx = new MyDbContext();
            ////拿到ctx对应的底层Connection
            //DbConnection con = ctx.Database.GetDbConnection();
            ////判断连接是否打开
            //if (con.State != System.Data.ConnectionState.Open)
            //{
            //    await con.OpenAsync();
            //}
            //using (DbCommand cmd = con.CreateCommand())
            //{
            //    cmd.CommandText = "select Price,Count(*) from T_Articles group by Price";
            //    using (DbDataReader render = await cmd.ExecuteReaderAsync())
            //    {
            //        while (await render.ReadAsync())
            //        {
            //            double price = render.GetDouble(0);
            //            int count = render.GetInt32(1);
            //            Console.WriteLine($"{price}: {count}");
            //        }
            //    }
            //}
            #endregion

            #region dapper替代上面的原生写法
            using MyDbContext ctx = new MyDbContext();
            DbConnection con = ctx.Database.GetDbConnection();

            IEnumerable<GroupArticlesByPrice>? res = con.Query<GroupArticlesByPrice>("select Price,Count(*) PCount from T_Articles group by Price");
            foreach (GroupArticlesByPrice item in res)
            {
                Console.WriteLine(item.Price + ": " + item.PCount);
            }
            #endregion
        }

        /// <summary>
        /// EF Core的非查询语句
        /// </summary>
        static async Task Main2(string[] args)
        {
            using MyDbContext ctx = new MyDbContext();
            // 1、执行非查询语句之外的所有语句：ExecuteSqlInterpolatedAsync()
            //int index = 11;
            //string str = "hello,boy";

            //await ctx.Database.ExecuteSqlInterpolatedAsync(
            //    $"insert into T_Articles(Title, Message, Price) select Title, {str}, Price from T_Articles where Id = {index}");

            // 2、执行查询语句
            //string name = "%一%";
            //IQueryable<Article> res = ctx.Articles.FromSqlInterpolated($"select * from T_Articles where title like {name} order by newId()");
            //foreach (Article item in res)
            //{
            //    Console.WriteLine(item.Title);
            //}

            // 3、查询语句的链式调用
            //string name = "%一%";
            //IQueryable<Article> res = ctx.Articles
            //    .FromSqlInterpolated($"select * from T_Articles where title like {name}");
            //IQueryable<Article> items = res
            //    .Include(d => d.comments)
            //    .OrderBy(d => Guid.NewGuid())
            //    .Skip(1)
            //    .Take(2);

            //foreach (Article item in items)
            //{
            //    Console.WriteLine(item.Title);
            //    foreach (Comment i in item.comments)
            //    {
            //        Console.WriteLine(i.Message);
            //    }
            //}
        }

        static async Task Main1(string[] args)
        {
            //PriatPage(1, 3);
            //using MyDbContext ctx = new MyDbContext();

            #region IQueryable读取数据的两种方法
            // 1、IQueryable分批从数据库读取数据；（内存占用小，数据库连接时间长）
            //IQueryable<Article> res = ctx.Articles.Where(d => d.Id > 0);

            //foreach (Article item in res)
            //{
            //    Console.WriteLine(item.Title);
            //    Thread.Sleep(10);
            //}

            // 2、IQueryable从数据库读取所有数据，放置内容中，再进行遍历。（内存占用大，数据库连接时间短）
            //var res1 = ctx.Articles.Where(d => d.Id > 0).ToArray();

            //foreach (Article item in res1)
            //{
            //    Console.WriteLine(item.Title);
            //    Thread.Sleep(10);
            //}
            #endregion

            #region EF Core中的异步方法
            // 1、获取总条数
            //int count = await ctx.Articles.CountAsync();
            //Console.WriteLine(count);

            // 2、新增数据
            //Article article = new Article
            //{
            //    Title = "Lovely mylife",
            //    Message = "热爱每一天",
            //    Price = 120
            //};
            //await ctx.Articles.AddAsync(article);
            //await ctx.SaveChangesAsync();

            // 3、获取数据
            //var res = await ctx.Articles.FirstAsync();
            //Console.WriteLine(res.Title);

            // 4、异步遍历数据
            //var res = ctx.Articles.Where(d => d.Id > 0);
            //常规遍历（一般情况下，常规遍历就可以解决问题，除非遇到性能瓶颈）
            //foreach (Article item in res)
            //{
            //    Console.WriteLine(item.Title);
            //}

            //方式一：使用 终结方法的异步方法
            //foreach (Article item in await res.ToArrayAsync())
            //{
            //    Console.WriteLine(item.Title);
            //}

            //方式二：使用 await foreach 方法
            //await foreach (Article item in res.AsAsyncEnumerable())
            //{
            //    Console.WriteLine(item.Title);
            //}
            #endregion
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