using MediatR;
using AccountService.Domain.Interfaces;
using AccountService.Domain.Entities;

namespace AccountService.Application.CQRS.Queries.GetAllAccounts;

public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
{
    private readonly IAccountRepository _repo;

    public GetAllAccountsQueryHandler(IAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Account>> Handle(
        GetAllAccountsQuery request,
        CancellationToken cancellationToken
        )
    {
        return await _repo.GetAllAsync();
    }
}
