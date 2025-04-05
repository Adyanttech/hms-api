using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Services;
using HospitalManagementSystem.Infrastructure.Context;
using HospitalManagementSystem.Infrastructure.Data;
using HospitalManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();


builder.Services.AddControllers();

// Registering ApplicationDbContext
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registering repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


// Registering the UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Registering Services
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IOTPService, OTPService>();

// Add services to the container.
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

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();
