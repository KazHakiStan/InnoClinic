using MediatR;

namespace AccountService.Application.CQRS.Commands.UpdateAccount;

public record UpdateAccountCommand(
    Guid Id,
    string? Email,
    string Password,
    string? PhoneNumber,
    bool IsEmailVerified,
    Guid CreatedBy,
    DateTime CreatedAt,
    Guid UpdatedBy,
    DateTime UpdatedAt
    ) : IRequest;
