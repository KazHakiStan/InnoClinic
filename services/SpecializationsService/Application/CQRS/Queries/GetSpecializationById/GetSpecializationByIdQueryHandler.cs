using MediatR;
using SpecializationService.Domain.Interfaces;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Application.CQRS.Queries.GetSpecializationById;

public class GetSpecializationByIdQueryHandler : IRequestHandler<GetSpecializationByIdQuery, Specialization?>
{
    private readonly ISpecializationRepository _repo;

    public GetSpecializationByIdQueryHandler(ISpecializationRepository repo) => _repo = repo;

    public async Task<Specialization?> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}
