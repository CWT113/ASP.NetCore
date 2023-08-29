using _07_充血模型;

using var ctx = new MyDBContext();

//User user = new User("王一博");
//user.ChangePassword("123456");
//ctx.Users.Add(user);
//ctx.SaveChanges();

User? data = ctx.Users.First(); 
data.remark = "bbbb";
Console.WriteLine(data.remark);

