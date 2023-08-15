using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace _08_MySQL并发控制
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 悲观并发控制
            //Console.WriteLine("请输入您的名字：");
            //string name = Console.ReadLine();

            //using MyDbContext ctx = new MyDbContext();
            ////开启事务
            //using IDbContextTransaction db = ctx.Database.BeginTransaction();
            ////House house = ctx.Houses.Single(d => d.Id == 1);

            //Console.WriteLine(DateTime.Now + "开始select for update");
            //// 1、加锁
            //House house = ctx.Houses.FromSqlInterpolated($"select * from T_Houses where Id = 1 for update").Single();
            //Console.WriteLine(DateTime.Now + "结束select for update");

            //if (!string.IsNullOrEmpty(house.Owner))
            //{
            //    if (house.Owner == name)
            //    {
            //        Console.WriteLine("房子已经被你抢到了！！");
            //    }
            //    else
            //    {
            //        Console.WriteLine("房子已经被【" + house.Owner + "】占了");
            //    }
            //    Console.ReadLine();
            //    return;
            //}
            //house.Owner = name;

            ////模拟并发操作，延迟5秒
            //Thread.Sleep(5000);
            //Console.WriteLine("恭喜你抢到了");

            //// 2、解锁
            //ctx.SaveChanges();
            //Console.WriteLine(DateTime.Now + "保存完成");
            ////提交事务
            //db.Commit();
            //Console.ReadLine();
            #endregion

            #region 乐观并发控制
            //Console.WriteLine("请输入您的名字：");
            //string name = Console.ReadLine();

            //using MyDbContext ctx = new MyDbContext();
            ////开启事务
            //using IDbContextTransaction db = ctx.Database.BeginTransaction();
            ////House house = ctx.Houses.Single(d => d.Id == 1);

            //Console.WriteLine(DateTime.Now + "开始select for update");
            //// 1、加锁
            //House house = ctx.Houses.FromSqlInterpolated($"select * from T_Houses where Id = 1 for update").Single();
            //Console.WriteLine(DateTime.Now + "结束select for update");

            //if (!string.IsNullOrEmpty(house.Owner))
            //{
            //    if (house.Owner == name)
            //    {
            //        Console.WriteLine("房子已经被你抢到了！！");
            //    }
            //    else
            //    {
            //        Console.WriteLine("房子已经被【" + house.Owner + "】占了");
            //    }
            //    //Console.ReadLine();
            //    return;
            //}
            //house.Owner = name;

            ////模拟并发操作，延迟5秒
            //Thread.Sleep(3000);

            ////提交事务
            //db.Commit();
            //// 2、解锁
            //try
            //{
            //    ctx.SaveChanges();
            //    Console.WriteLine("恭喜你抢到了");
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    Console.WriteLine("并发访问失败！");
            //}
            
            //Console.ReadLine();
            #endregion
        }
    }
}