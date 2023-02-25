// 1. Usings para trabajar con entityFramework
using Microsoft.EntityFrameworkCore;
using univercityApiBackend.DataAccess;
using univercityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// 2. conexion con SQL server express
const string CONNECTIONNAME = "UniversityDB";
var ConnectionStrings = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. add contex 
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(ConnectionStrings));
// 7. Add services of JWT autorization
//TODO
//builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//TOTO: config swager para que tenga en cuenta la autorizacion jwt
builder.Services.AddSwaggerGen();

// 4. add custom services (folder services)
builder.Services.AddScoped<IEstudentService, StudentService>();
// TODO:  add the rest services

//5. CORS configuration
builder.Services.AddCors(options=>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    }
        );
});

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
// 6. tell app use cors
app.UseCors("CorsPolicy");

app.Run();
