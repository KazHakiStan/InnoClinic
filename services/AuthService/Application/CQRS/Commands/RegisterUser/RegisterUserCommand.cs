using MediatR;

namespace AuthService.Application.CQRS.Commands.RegisterUser;

public record RegisterUserCommand(
    string Email,
    string Password,
    string Role
    ) : IRequest<Unit>;
