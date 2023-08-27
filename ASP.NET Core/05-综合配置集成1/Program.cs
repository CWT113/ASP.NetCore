using System.Data.SqlClient;
using _05_综合配置集成1;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var webBuilder = builder.Host;
webBuilder.ConfigureAppConfiguration((hostCtx, configBuilder) => {
    string connStr = builder.Configuration.GetSection("ConnectionString").Value;
    configBuilder.AddDbConfiguration(() => new SqlConnection(connStr), reloadOnChange: true, reloadInterval: TimeSpan.FromSeconds(2));
});

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    //在 program.cs 中读取配置的一种方法
    string constr = builder.Configuration.GetSection("Redis").Value;
    return ConnectionMultiplexer.Connect(constr);
});

builder.Services.Configure<StmpSetting>(builder.Configuration.GetSection("Smtp"));

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
