using System.Data.SqlClient;
using _05_�ۺ����ü���1;
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
    //�� program.cs �ж�ȡ���õ�һ�ַ���
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
