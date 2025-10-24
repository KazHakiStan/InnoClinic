using MediatR;
using DoctorService.Domain.Interfaces;

namespace DoctorService.Application.CQRS.Commands.DeleteDoctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDoctorRepository _repo;

    public DeleteDoctorCommandHandler(IDoctorRepository repo) => _repo = repo;

    public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Doctor {request.Id} not found.");
        await _repo.DeleteAsync(doctor);
        return Unit.Value;
    }
}
