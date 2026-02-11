namespace PMS.Application.DTOs;

public class RegisterPatientRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ContactNumber { get; set; }
    public List<InsuranceDto> Insurances { get; set; }
}
