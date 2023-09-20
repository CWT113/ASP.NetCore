using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity;

public class MyDbcontext : IdentityDbContext<MyUser, MyRole, long>
{
    public MyDbcontext(DbContextOptions<MyDbcontext> options) : base(options)
    {
    }
}
