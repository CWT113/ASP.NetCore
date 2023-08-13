using _01_基本使用;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace _02_组织结构树
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region 数据库中插入数据
            ////根节点
            //OrgUnits ouRoot = new OrgUnits { Name = "中科集团全球总部" };

            ////子节点1
            //OrgUnits ouAsia = new OrgUnits { Name = "中科集团亚太总部" };
            //ouRoot.Childrens.Add(ouAsia);

            //OrgUnits ouChina = new OrgUnits { Name = "中科中国" };
            //ouAsia.Childrens.Add(ouChina);
            //OrgUnits ouSg = new OrgUnits { Name = "中科新加坡" };
            //ouAsia.Childrens.Add(ouSg);

            ////子节点2
            //OrgUnits ouAmerica = new OrgUnits { Name = "中科集团美洲总部" };
            //ouRoot.Childrens.Add(ouAmerica);

            //OrgUnits ouUSA = new OrgUnits { Name = "中科美国" };
            //ouAmerica.Childrens.Add(ouUSA);
            //OrgUnits ouCan = new OrgUnits { Name = "中科加拿大" };
            //ouAmerica.Childrens.Add(ouCan);

            //using (MyDbContext ctx = new MyDbContext())
            //{
            //    ctx.OrgUnits.Add(ouRoot);

            //    await ctx.SaveChangesAsync();
            //}
            #endregion

            #region 递归打印子节点
            using MyDbContext ctx = new MyDbContext();
            OrgUnits ouRoot = ctx.OrgUnits.Single(d => d.Parents == null);
            Console.WriteLine(ouRoot.Name);
            PaintChildrens(1, ctx, ouRoot);
            #endregion
        }

        /// <summary>
        /// 循环递归打印所有子节点
        /// </summary>
        /// <param name="indetLevel">缩进等级</param>
        /// <param name="ctx">MyDbContext实例</param>
        /// <param name="parent">父节点</param>
        private static void PaintChildrens(int indetLevel, MyDbContext ctx, OrgUnits parent)
        {
            var children = ctx.OrgUnits.Where(d => d.Parents == parent);
            foreach (OrgUnits child in children)
            {
                Console.WriteLine(new string('\t', indetLevel) + child.Name);
                //递归打印子节点
                PaintChildrens(indetLevel, ctx, child);
            }
        }
    }
}