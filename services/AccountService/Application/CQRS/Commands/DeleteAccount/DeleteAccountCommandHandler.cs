using MediatR;
using AccountService.Domain.Interfaces;

namespace AccountService.Application.CQRS.Commands.DeleteAccount;

public class DeleteAccountCommandHandler : IRequest<DeleteAccountCommand>
{
    private readonly IAccountRepository _repo;

    public DeleteAccountCommandHandler(IAccountRepository repo) => _repo = repo;

    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Doctor {request.Id} not found.");
        await _repo.DeleteAsync(doctor);
    }
}

