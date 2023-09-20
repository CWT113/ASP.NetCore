using System.Reflection;
using FluentValidation.AspNetCore;
using Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//配置FluentValidation
builder.Services.AddFluentValidation(option =>
{
    Assembly assembly = Assembly.GetExecutingAssembly();
    option.RegisterValidatorsFromAssembly(assembly);
});

builder.Services.AddDbContext<MyDbcontext>(option =>
{
    option.UseSqlServer("Data Source=LENOVO\\SQLSERVER;Initial Catalog=validation Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});

//配置Identity框架
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<MyUser>(option =>
{
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireDigit = false;
    option.Password.RequiredLength = 6;
    //配置是否启用邮件形式，邮件形式的token特别长，此处不启用
    option.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
});
IdentityBuilder identityBuilder = new IdentityBuilder(typeof(MyUser), typeof(MyRole), builder.Services);
identityBuilder.AddEntityFrameworkStores<MyDbcontext>()
    .AddDefaultTokenProviders()
    .AddUserManager<UserManager<MyUser>>()
    .AddRoleManager<RoleManager<MyRole>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
