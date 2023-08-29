using _07_充血模型;

using var ctx = new MyDBContext();

//User user = new User("王一博");
//user.ChangePassword("123456");
//ctx.Users.Add(user);
//ctx.SaveChanges();

//User? data = ctx.Users.First(); 
//Console.WriteLine(data.remark);

//Entity entity = new Entity
//{
//    Name = "一碗混沌",
//    Type = _07_充血模型.Type.USD
//};

//Entity entity1 = new Entity
//{
//    Name = "一颗糖",
//    Type = _07_充血模型.Type.CNY
//};

//ctx.Entities.Add(entity);
//ctx.Entities.Add(entity1);

Shop shop = new Shop
{
    Name = "王一博的商店",
    Location = new Geo(2,5)
};

ctx.Shop.Add(shop);
ctx.SaveChanges();
