using System.Reflection;
using Zack.EventBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//���� Zack.EventBus
builder.Services.Configure<IntegrationEventRabbitMQOptions>(opt =>
{
    opt.HostName = "127.0.0.1";
    opt.ExchangeName = "exchangeEventBusDemo1";
});
builder.Services.AddEventBus("queue1", Assembly.GetExecutingAssembly());

var app = builder.Build();
app.UseEventBus();

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
