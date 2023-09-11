using ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.Configure<MvcOptions>(option =>
{
    option.Filters.Add<RateLimitFilter>();
    option.Filters.Add<ActionFilters>();
    option.Filters.Add<ActionFilters2>();
    option.Filters.Add<TransactionScopeFilter>();
});

builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer("Data Source=LENOVO\\SQLSERVER;Initial Catalog=Demo10;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});

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
