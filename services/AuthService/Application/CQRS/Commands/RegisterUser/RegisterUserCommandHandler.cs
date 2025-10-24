using System.Security.Cryptography;
using System.Text;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using MediatR;

namespace AuthService.Application.CQRS.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly IUserAccountRepository _repo;

    public RegisterUserCommandHandler(IUserAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _repo.ExistsByEmailAsync(request.Email, cancellationToken))
            throw new InvalidOperationException("User with this email already exists.");

        var hashedPassword = HashPassword(request.Password);

        var user = new UserAccount
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = hashedPassword,
            Role = request.Role
        };

        await _repo.AddAsync(user, cancellationToken);
        return Unit.Value;
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
}

