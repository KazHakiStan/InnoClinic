namespace AccountService.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public string? Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public bool IsEmailVerified { get; set; } = false;
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}
