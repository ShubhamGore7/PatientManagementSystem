using Microsoft.EntityFrameworkCore;
using PMS.Application.Interfaces;
using PMS.Application.UseCases.RegisterPatient;
using PMS.Infrastructure.Persistence;
using PMS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// DI

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<RegisterPatientHandler>();

var app = builder.Build();

// Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAngular");//Cors


app.UseAuthorization();

app.MapControllers();

app.Run();
