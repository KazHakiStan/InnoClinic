namespace PatientService.Domain.Entities;

public class Patient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public bool IsLinkedToAccount { get; set; }
    public DateTime DateOfBirth { get; set; }
}
