using Microsoft.AspNetCore.Mvc;
using MediatR;
using AuthService.Application.CQRS.Commands.RegisterUser;
using AuthService.Application.CQRS.Commands.LoginUser;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using System.Security.Claims;

namespace AuthService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IJwtTokenService _jwtService;

    public AuthController(IMediator mediator, IJwtTokenService jwtService)
    {
        _jwtService = jwtService;
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        await _mediator.Send(new RegisterUserCommand(dto.Email, dto.Password, dto.Role));
        return Ok(new { message = "User registered successfully." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _mediator.Send(new LoginUserCommand(dto.Email, dto.Password));

        if (token is null) return Unauthorized(new { message = "Invalid email or password." });

        return Ok(new { token });
    }

    [HttpPost("validate")]
    public IActionResult ValidateToken([FromBody] TokenValidationRequest request)
    {
        var principal = _jwtService.ValidateToken(request.Token);

        if (principal is null)
        {
            return Unauthorized(new { valid = false });
        }

        return Ok(new
        {
            valid = true,
            userId = principal.FindFirstValue(ClaimTypes.NameIdentifier),
            email = principal.FindFirstValue(ClaimTypes.Email),
            role = principal.FindFirstValue(ClaimTypes.Role)
        });
    }
}
