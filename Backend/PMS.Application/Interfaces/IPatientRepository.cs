using PMS.Domain.Entities;

namespace PMS.Application.Interfaces;

public interface IPatientRepository
{
    Task AddAsync(Patient patient);
}
