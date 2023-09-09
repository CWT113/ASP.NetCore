using System.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
    private readonly MyDBContext ctx;

    public DemoController(MyDBContext ctx)
    {
        this.ctx = ctx;
    }

    [HttpPost]
    [Route("Add")]
    public string Add()
    {
        using TransactionScope tx = new TransactionScope();
        Book book1 = new Book { Name = "aa", Price = 9.9 };
        ctx.books.Add(book1);
        ctx.SaveChanges();

        Person person1 = new Person { Name = "莎", Age = 99 };
        ctx.people.Add(person1);
        ctx.SaveChanges();
        //没有Complete()，事务也会回滚
        tx.Complete();

        return "OK";
    }

    [HttpPost]
    [Route("AddAsync")]
    public async Task<string> AddAsync()
    {
        using TransactionScope tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        Book book1 = new Book { Name = "aa", Price = 9.9 };
        ctx.books.Add(book1);
        await ctx.SaveChangesAsync();

        Person person1 = new Person { Name = "莎", Age = 99 };
        ctx.people.Add(person1);
        await ctx.SaveChangesAsync();
        //没有Complete()，事务也会回滚
        tx.Complete();

        return "OK";
    }
}
