using _02_ǰ��˷���.Controllers;
using Zack.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ע��Calculate��
builder.Services.AddScoped<Calculate>();

//ʹ�� Zack.commons ʵ�ָ��Ե�����ע��
var asms = ReflectionHelper.GetAllReferencedAssemblies();
builder.Services.RunModuleInitializers(asms);

//������ÿ���
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

//ʹ�ÿ�������
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
