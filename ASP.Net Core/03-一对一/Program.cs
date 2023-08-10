namespace _03_一对一
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Order o1 = new Order
                {
                    Name = "盗墓笔记"
                };

                Delivery d1 = new Delivery
                {
                    Name = "邮政快递",
                    Number = "62230023409233875",
                    Order = o1
                };

                //通过 d1 添加 o1
                ctx.Deliverys.Add(d1);
                //ctx.Orders.Add(o1); //暴力手段：不知道存储那张表时，直接两张表都存

                await ctx.SaveChangesAsync();
            }
        }
    }
}