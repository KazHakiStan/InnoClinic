using System.Security.Claims;
using AuthService.Domain.Entities;

namespace AuthService.Infrastructure.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(UserAccount userAccount);
    ClaimsPrincipal? ValidateToken(string token);
}

