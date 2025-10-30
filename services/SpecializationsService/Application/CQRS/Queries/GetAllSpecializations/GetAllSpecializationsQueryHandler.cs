using MediatR;
using SpecializationService.Domain.Interfaces;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Application.CQRS.Queries.GetAllSpecializations;

public class GetAllSpecializationsQueryHandler : IRequestHandler<GetAllSpecializationsQuery, IEnumerable<Specialization>>
{
    private readonly ISpecializationRepository _repo;

    public GetAllSpecializationsQueryHandler(ISpecializationRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Specialization>> Handle(
        GetAllSpecializationsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
