using MediatR;
using ServicesService.Domain.Interfaces;

namespace ServicesService.Application.CQRS.Commands.DeleteService;

public class DeleteServiceCommandHandler : IRequest<DeleteServiceCommand>
{
    private readonly IServiceRepository _repo;

    public DeleteServiceCommandHandler(IServiceRepository repo) => _repo = repo;

    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Doctor {request.Id} not found.");
        await _repo.DeleteAsync(doctor);
    }
}

