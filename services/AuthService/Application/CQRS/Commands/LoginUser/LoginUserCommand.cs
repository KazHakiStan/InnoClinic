using MediatR;

namespace AuthService.Application.CQRS.Commands.LoginUser;

public record LoginUserCommand(
    string Email,
    string Password
    ) : IRequest<string?>;
