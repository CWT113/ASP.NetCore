using SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ע��SignalR
builder.Services.AddSignalR();

//ע�����
string[] urls = new[] { "http://localhost:3000", "http://localhost:5173" };
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder => builder.WithOrigins(urls)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials())
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

//ӳ��·��
app.MapHub<MyHub>("/myhub");

app.MapControllers();

app.Run();
