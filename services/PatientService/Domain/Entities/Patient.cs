namespace PatientService.Domain.Entities;

public class Patient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public bool IsLinkedToAccount { get; set; } = false;
    public DateTime DateOfBirth { get; set; }
    public Guid AccountId { get; set; }
}
