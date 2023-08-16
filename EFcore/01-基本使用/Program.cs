
using Microsoft.EntityFrameworkCore;

namespace _01_基本使用
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (MyDbContext context = new MyDbContext())
            {
                #region 1、添加文章和评论
                ////创建一篇文章
                //Article ar1 = new Article
                //{
                //    Title = "为自己写的每一行代码负责！",
                //    Message = "今天犯了一个错，吃一堑长一智，下次一定要注意！要有进取精神，而不是随遇而安，一屋不扫何以扫天下！"
                //};

                ////创建两条评论
                //Comment c1 = new Comment { Message = "加油，王一博" };
                //Comment c2 = new Comment { Message = "下一不能再犯了！" };
                ////将评论添加到文章
                //ar1.comments.Add(c1);
                //ar1.comments.Add(c2);

                //context.Articles.Add(ar1);

                ////提交修改
                //await context.SaveChangesAsync();
                #endregion

                #region 2、查询文章和评论(大表驱动小表)
                //Article article = context.Articles.Include(x => x.comments).Single(x => x.Id == 2);
                //Console.WriteLine(article.Id);
                //Console.WriteLine(article.Title);
                //Console.WriteLine(article.Message);

                //foreach (Comment item in article.comments)
                //{
                //    Console.WriteLine(item.Id + ": " + item.Message);
                //}
                #endregion

                #region 3、查询文章和评论(小表驱动大表)
                //Comment m1 = context.Comments.Include(x => x.Article).Single(x => x.Id == 3);
                //Console.WriteLine(m1.Id + m1.Message);
                //Console.WriteLine("Id: " + m1.Article.Id + m1.Article.Title);
                #endregion

                #region 4、单向导航属性
                //User u1 = new User { Name = "王一博" };
                //User u2 = new User { Name = "陈伟霆" };
                //Leave l1 = new Leave { Remarks = "回家看望爸妈", Applicant = u1, Approver = u2 };

                //User u3 = new User { Name = "sunny" };
                //User u4 = new User { Name = "tomx" };
                //Leave l2 = new Leave { Remarks = "出去境外诈骗", Applicant = u3, Approver = u4 };

                //context.Leaves.Add(l2);
                //await context.SaveChangesAsync();
                #endregion
            }
        }
    }
}