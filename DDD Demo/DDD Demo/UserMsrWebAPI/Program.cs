using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMsr.Infrastracture;
using UserMsrWebAPI.Configuration;
using UserMsrWebAPI.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//����ѩ��ID
builder.Services.AddOtherConfiguration();
//���ù�����Ԫ������
builder.Services.Configure<MvcOptions>(d =>
{
    d.Filters.Add<UnitOfWorkFilter>();
});
//�������ݿ�
builder.Services.AddDbContext<UserDBContext>(d =>
{
    d.UseSqlServer("");
});
//����mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

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
