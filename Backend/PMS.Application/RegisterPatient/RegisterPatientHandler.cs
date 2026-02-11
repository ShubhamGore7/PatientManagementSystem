using PMS.Application.DTOs;
using PMS.Application.Interfaces;
using PMS.Domain.Entities;

namespace PMS.Application.UseCases.RegisterPatient;

public class RegisterPatientHandler
{
    private readonly IPatientRepository _repository;

    public RegisterPatientHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RegisterPatientRequest request)
    {
        var patient = new Patient(
            request.FirstName,
            request.LastName,
            request.DateOfBirth,
            request.ContactNumber
        );

        foreach (var insurance in request.Insurances)
        {
            patient.AddInsurance(
                insurance.PolicyNumber,
                insurance.ProviderName,
                insurance.IsPrimary
            );
        }

        await _repository.AddAsync(patient);
    }
}
