using Microsoft.EntityFrameworkCore;

namespace _04_多对多
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyDbConfig ctx = new MyDbConfig();

            #region 添加数据
            //Student s1 = new Student { Name = "张三" };
            //Student s2 = new Student { Name = "李逵" };
            //Student s3 = new Student { Name = "王一博" };

            //Teacher t1 = new Teacher { Name = "Tom" };
            //Teacher t2 = new Teacher { Name = "sunny" };
            //Teacher t3 = new Teacher { Name = "siri" };

            //s1.Teachers.Add(t1);
            //s1.Teachers.Add(t2);

            //s2.Teachers.Add(t2);
            //s2.Teachers.Add(t3);

            //s3.Teachers.Add(t1);
            //s3.Teachers.Add(t2);
            //s3.Teachers.Add(t3);

            ////暴力手段：两张表都添加到数据库中
            //ctx.Teachers.Add(t1);
            //ctx.Teachers.Add(t2);
            //ctx.Teachers.Add(t3);

            //ctx.Students.Add(s1);
            //ctx.Students.Add(s2);
            //ctx.Students.Add(s3);

            //ctx.SaveChanges();
            #endregion

            #region 查询数据
            //var teachers = ctx.Teachers.Include(d => d.Students);
            //foreach (Teacher teacher in teachers)
            //{
            //    Console.WriteLine(teacher.Name);
            //    foreach (Student item in teacher.Students)
            //    {
            //        Console.WriteLine(new string('\t',1) + item.Name);
            //    }
            //}
            #endregion
        }
    }
}