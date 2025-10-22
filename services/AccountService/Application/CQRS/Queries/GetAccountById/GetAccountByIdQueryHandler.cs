using MediatR;
using AccountService.Domain.Interfaces;
using AccountService.Domain.Entities;

namespace AccountService.Application.CQRS.Queries.GetAccountById;

public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account?>
{
    private readonly IAccountRepository _repo;

    public GetAccountByIdQueryHandler(IAccountRepository repo) => _repo = repo;

    public async Task<Account?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}

