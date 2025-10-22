using MediatR;
using AccountService.Domain.Entities;

namespace AccountService.Application.CQRS.Queries.GetAccountById;

public record GetAccountByIdQuery(Guid Id) : IRequest<Account?>;

