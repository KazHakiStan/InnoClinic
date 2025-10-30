using MediatR;
using OfficesService.Domain.Interfaces;
using OfficesService.Domain.Entities;

namespace OfficesService.Application.CQRS.Queries.GetOfficeById;

public class GetOfficeByIdQueryHandler : IRequestHandler<GetOfficeByIdQuery, Office?>
{
    private readonly IOfficeRepository _repo;

    public GetOfficeByIdQueryHandler(IOfficeRepository repo) => _repo = repo;

    public async Task<Office?> Handle(GetOfficeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}

