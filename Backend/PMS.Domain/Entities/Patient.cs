namespace PMS.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string ContactNumber { get; private set; }

    private readonly List<PatientInsurance> _insurances = new();
    public IReadOnlyCollection<PatientInsurance> Insurances => _insurances;

    private Patient() { } // EF

    public Patient(string firstName, string lastName, DateTime dob, string contact)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
        ContactNumber = contact;
    }

    public void AddInsurance(string policyNumber, string providerName, bool isPrimary)
    {
        _insurances.Add(new PatientInsurance(policyNumber, providerName, isPrimary));
    }
}
