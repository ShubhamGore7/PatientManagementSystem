using Microsoft.EntityFrameworkCore;
using PMS.Application.Interfaces;
using PMS.Application.UseCases.RegisterPatient;
using PMS.Infrastructure.Persistence;
using PMS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// =====================
// SERVICES
// =====================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Dependency Injection
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<RegisterPatientHandler>();

// IMPORTANT for Render
builder.WebHost.UseUrls("http://0.0.0.0:10000");

var app = builder.Build();

// =====================
// MIDDLEWARE
// =====================

// Enable Swagger in Production
app.UseSwagger();
app.UseSwaggerUI();

// Optional: Root endpoint to avoid 404
app.MapGet("/", () => "Patient Management System API is Running 🚀");

// app.UseHttpsRedirection();  // Disable if causing redirect issues on Render

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
