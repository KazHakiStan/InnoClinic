namespace DoctorService.Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid AccountId { get; set; }
    public int CareerStartYear { get; set; }
    public string Status { get; set; } = null!;
}
