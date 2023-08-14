using System.Data.Common;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _07_跟踪快照
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyDbContext ctx = new MyDbContext();

            #region 快照跟踪
            //获取3条数据
            //Article[] res = ctx.Articles.Take(3).ToArray();
            //Article a1 = res[0];
            //Article a2 = res[1];
            //Article a3 = res[2];//此条被跟踪，但也不动

            //Article a4 = new Article { Title = "悲伤留给自己", Message = "hello，树" };
            //Article a5 = new Article { Title = "一剑开天门", Message = "阻止仙人垂钓人间气运" };//此条不动，未被跟踪

            //a1.Price += 1;//修改一条
            //ctx.Remove(a2);//删除一条
            //ctx.Add(a4);//添加一条

            //// 1、查看状态
            //EntityEntry e1 = ctx.Entry(a1);
            //EntityEntry e2 = ctx.Entry(a2);
            //EntityEntry e3 = ctx.Entry(a3);
            //EntityEntry e4 = ctx.Entry(a4);
            //EntityEntry e5 = ctx.Entry(a5);

            //Console.WriteLine(e1);
            //Console.WriteLine(e2);
            //Console.WriteLine(e3);
            //Console.WriteLine(e4);
            //Console.WriteLine(e5);

            //// 2、查看快照信息
            //Console.WriteLine(e1.DebugView.LongView);
            #endregion

            #region 取消快照跟踪
            //什么时候用？当我们通过DBContext查询出来的内容不做修改，只是展示时，就可以通过 AsNoTracking() 方法来取消快照跟踪。
            //Article[] res = ctx.Articles.AsNoTracking().Take(3).ToArray();
            //foreach (Article item in res)
            //{
            //    Console.WriteLine(item.Message);
            //}

            //Console.WriteLine(ctx.Entry(res[0]).State);//Detached
            #endregion

            #region 跟踪快照的“小技巧”（不推荐使用）
            // 1、将查询和更新合并为一句sql
            //Article a = new Article { Id = 5, Price = 7890 };
            //EntityEntry entry = ctx.Entry(a);
            //entry.Property("Price").IsModified = true;//将其状态手动设置为 true

            //Console.WriteLine(ctx.Entry(a).State);
            //Console.WriteLine(entry.DebugView.LongView);

            //ctx.SaveChanges();

            // 2、将查询和删除合并为一句sql
            //Article a = new Article { Id = 24588 };
            //ctx.Entry(a).State = EntityState.Deleted;//将其手动设置为 Deleted
            //ctx.SaveChanges();
            #endregion

            #region 全局查询筛选器
            // 1、将第一条软删除
            //Article res = ctx.Articles.Single(d => d.Id == 1);
            //res.IsDeleted = true;
            //ctx.SaveChanges();

            // 2、在 ArticlesConfig 中设置全局查询筛选器
            //var res = ctx.Articles.Where(d => d.Id >= 1).Take(4);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Id + ": " + item.Title);
            //}
            #endregion

            #region 忽略全局筛选过滤器
            // 3、忽略全局筛选过滤器
            //var res = ctx.Articles.IgnoreQueryFilters().Where(d => d.IsDeleted == true);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Id + ": " + item.Title);
            //}
            #endregion
        }
    }
}