using MediatR;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;

namespace AuthService.Application.CQRS.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserAccount?>
{
    private readonly IUserAccountRepository _repo;

    public GetUserByEmailQueryHandler(IUserAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<UserAccount?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByEmailAsync(request.Email, cancellationToken);
    }
}
