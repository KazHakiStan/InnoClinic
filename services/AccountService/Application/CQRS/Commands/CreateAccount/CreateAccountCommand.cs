using MediatR;

namespace AccountService.Application.CQRS.Commands.CreateAccount;

public record CreateAccountCommand(string? Email, string Password, string? PhoneNumber, bool IsEmailVerified, Guid CreatedBy, DateTime CreatedAt, Guid UpdatedBy, DateTime UpdatedAt) : IRequest<Guid>;
