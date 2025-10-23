using MediatR;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Application.CQRS.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string?>
{
    private readonly IUserAccountRepository _repo;
    private readonly IJwtTokenService _jwtService;

    public LoginUserCommandHandler(IUserAccountRepository repo, IJwtTokenService jwtService)
    {
        _repo = repo;
        _jwtService = jwtService;
    }

    public async Task<string?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repo.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null || !VerifyPassword(request.Password, user.PasswordHash))
            return null;

        return _jwtService.GenerateToken(user);
    }

    private static bool VerifyPassword(string password, string storedHash)
    {
        using var sha = SHA256.Create();
        var computed = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        return computed == storedHash;
    }
}
