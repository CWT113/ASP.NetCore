using Zack.ASPNETCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注册内存缓存
builder.Services.AddMemoryCache();

//注册Zack.ASPNETCORE中封装的 IMemoryCacheHelper 类
builder.Services.AddScoped<IMemoryCacheHelper, MemoryCacheHelper>();

//注册redis
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = "localhost";
    option.InstanceName = "wyb_";
});

//注册Zack.ASPNETCORE中封装的 IDistributedCacheHelper 类
builder.Services.AddScoped<IDistributedCacheHelper, DistributedCacheHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//设置服务器端缓存
app.UseResponseCaching();

app.MapControllers();

app.Run();
