using Zack.ASPNETCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ע���ڴ滺��
builder.Services.AddMemoryCache();

//ע��Zack.ASPNETCORE�з�װ�� IMemoryCacheHelper ��
builder.Services.AddScoped<IMemoryCacheHelper, MemoryCacheHelper>();

//ע��redis
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = "localhost";
    option.InstanceName = "wyb_";
});

//ע��Zack.ASPNETCORE�з�װ�� IDistributedCacheHelper ��
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

//���÷������˻���
app.UseResponseCaching();

app.MapControllers();

app.Run();
