using MediatR;
using AccountService.Domain.Entities;

namespace AccountService.Application.CQRS.Queries.GetAllAccounts;

public record GetAllAccountsQuery : IRequest<IEnumerable<Account>>;
