namespace PMS.Domain.Entities;

public class PatientInsurance
{
    public Guid Id { get; private set; }
    public string PolicyNumber { get; private set; }
    public string ProviderName { get; private set; }
    public bool IsPrimary { get; private set; }

    public Guid PatientId { get; private set; }

    private PatientInsurance() { } // EF 

    public PatientInsurance(string policyNumber, string providerName, bool isPrimary)
    {
        Id = Guid.NewGuid();
        PolicyNumber = policyNumber;
        ProviderName = providerName;
        IsPrimary = isPrimary;
    }
}
