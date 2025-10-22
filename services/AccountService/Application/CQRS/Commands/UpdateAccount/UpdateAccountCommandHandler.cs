using MediatR;
using AutoMapper;
using AccountService.Domain.Interfaces;
using AccountService.Domain.Entities;

namespace AccountService.Application.CQRS.Commands.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
{
    private readonly IAccountRepository _repo;
    private readonly IMapper _mapper;

    public UpdateAccountCommandHandler(IAccountRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(request);
        await _repo.UpdateAsync(account);
        return Unit.Value;
    }
}
