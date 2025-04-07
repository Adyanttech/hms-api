using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Services;
using HospitalManagementSystem.Infrastructure.Models;
using HospitalManagementSystem.Infrastructure.Data;
using HospitalManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Application.AutoMapper;

var builder = WebApplication.CreateBuilder();

// Add services to the container
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

// Add Swagger and CORS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HospitalManagementSystem API", Version = "v1" });
});

// Build the app after all services are registered
var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagementSystem API v1"));
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
