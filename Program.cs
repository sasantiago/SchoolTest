using School.Data;
using Microsoft.EntityFrameworkCore;
using School.Services.Courses;
using School.Services.Teachers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Conexion base de datos
builder.Services.AddControllers(); 

builder.Services.AddDbContext<SchoolContext>(
    options => options.UseMySql(
    builder.Configuration.GetConnectionString("MySql"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2")));

builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();
// builder.Services.AddScoped<IPacientesRepository, PacienteRepository>();
// builder.Services.AddScoped<IPacientesRepository, PacienteRepository>();
// builder.Services.AddScoped<IPacientesRepository, PacienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
