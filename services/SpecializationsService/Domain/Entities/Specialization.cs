namespace SpecializationService.Domain.Entities;

public class Specialization
{
    public Guid Id { get; set; }
    public string SpecializationName { get; set; } = null!;
    public bool IsActive { get; set; }
}
