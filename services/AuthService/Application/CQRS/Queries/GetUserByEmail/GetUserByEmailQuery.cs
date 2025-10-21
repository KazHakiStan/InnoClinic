using MediatR;
using AuthService.Domain.Entities;

namespace AuthService.Application.CQRS.Queries.GetUserByEmail;

public record GetUserByEmailQuery(
    string Email
    ) : IRequest<UserAccount?>;
