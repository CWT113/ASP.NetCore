using _02_前后端分离.Controllers;
using Zack.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注入Calculate类
builder.Services.AddScoped<Calculate>();

//使用 Zack.commons 实现各自的依赖注入
var asms = ReflectionHelper.GetAllReferencedAssemblies();
builder.Services.RunModuleInitializers(asms);

//后端配置跨域
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(d =>
    {
        d.WithOrigins(new string[] { "http://localhost:5173" })
            .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//使用跨域配置
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
