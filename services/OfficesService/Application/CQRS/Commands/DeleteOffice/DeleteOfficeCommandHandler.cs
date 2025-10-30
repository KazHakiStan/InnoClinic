using MediatR;
using OfficesService.Domain.Interfaces;

namespace OfficesService.Application.CQRS.Commands.DeleteOffice;

public class DeleteOfficeCommandHandler : IRequest<DeleteOfficeCommand>
{
    private readonly IOfficeRepository _repo;

    public DeleteOfficeCommandHandler(IOfficeRepository repo) => _repo = repo;

    public async Task Handle(DeleteOfficeCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Doctor {request.Id} not found.");
        await _repo.DeleteAsync(doctor);
    }
}

