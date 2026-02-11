using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PMS.Domain.Entities;
using PMS.Infrastructure.Persistence.Configurations;

namespace PMS.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<PatientInsurance> PatientInsurances => Set<PatientInsurance>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
    }
}
