using MediatR;
using AutoMapper;
using AccountService.Domain.Interfaces;
using AccountService.Domain.Entities;

namespace AccountService.Application.CQRS.Commands.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IAccountRepository _repo;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IAccountRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(request);
        account.Id = Guid.NewGuid();
        await _repo.AddAsync(account);
        return account.Id;
    }
}
