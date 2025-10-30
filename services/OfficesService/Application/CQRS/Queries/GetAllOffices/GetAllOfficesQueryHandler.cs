using MediatR;
using OfficesService.Domain.Interfaces;
using OfficesService.Domain.Entities;

namespace OfficesService.Application.CQRS.Queries.GetAllOffices;

public class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, IEnumerable<Office>>
{
    private readonly IOfficeRepository _repo;

    public GetAllOfficesQueryHandler(IOfficeRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Office>> Handle(
        GetAllOfficesQuery request,
        CancellationToken cancellationToken
        )
    {
        return await _repo.GetAllAsync();
    }
}
