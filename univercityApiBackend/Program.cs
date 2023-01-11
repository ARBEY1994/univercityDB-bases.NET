// 1. Usings para trabajar con entityFramework
using Microsoft.EntityFrameworkCore;
using univercityApiBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// 2. conexion con SQL server express
const string CONNECTIONNAME = "UniversityDB";
var ConnectionStrings = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. add contex 
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(ConnectionStrings));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
