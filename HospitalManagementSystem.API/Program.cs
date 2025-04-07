using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Services;
using HospitalManagementSystem.Infrastructure.Models;
using HospitalManagementSystem.Infrastructure.Data;
using HospitalManagementSystem.Infrastructure.Interfaces;
using HospitalManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Application.AutoMapper;

var builder = WebApplication.CreateBuilder();


builder.Services.AddControllers();

// Registering ApplicationDbContext
builder.Services.AddDbContext<HmsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseConnection")));

// Registering repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


// Registering the UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Registering Services
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<IOTPService, OTPService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
