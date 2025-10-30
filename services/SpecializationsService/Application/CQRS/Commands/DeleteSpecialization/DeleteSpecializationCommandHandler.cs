using MediatR;
using SpecializationService.Domain.Interfaces;

namespace SpecializationService.Application.CQRS.Commands.DeleteSpecialization;

public class DeleteSpecializationCommandHandler : IRequest<DeleteSpecializationCommand>
{
    private readonly ISpecializationRepository _repo;

    public DeleteSpecializationCommandHandler(ISpecializationRepository repo) => _repo = repo;

    public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        var spec = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Specialization {request.Id} not found.");
        await _repo.DeleteAsync(spec);
    }
}
