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

            //获取3条数据
            Article[] res = ctx.Articles.Take(3).ToArray();
            Article a1 = res[0];
            Article a2 = res[1];
            Article a3 = res[2];

            Article a4 = new Article { Title = "悲伤留给自己", Message = "hello，树" };
            Article a5 = new Article { Title = "一剑开天门", Message = "阻止仙人垂钓人间气运" };

            a1.Price += 1;
            ctx.Remove(a2);
            ctx.Add(a4);

            // 1、查看状态
            EntityEntry e1 = ctx.Entry(a1);
            EntityEntry e2 = ctx.Entry(a2);
            EntityEntry e3 = ctx.Entry(a3);
            EntityEntry e4 = ctx.Entry(a4);
            EntityEntry e5 = ctx.Entry(a5);

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);
            Console.WriteLine(e4);
            Console.WriteLine(e5);

            // 2、查看快照信息
            Console.WriteLine(e1.DebugView.LongView);
        }
    }
}