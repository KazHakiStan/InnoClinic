using MediatR;
using ServicesService.Domain.Entities;
using ServicesService.Domain.Interfaces;

namespace ServicesService.Application.CQRS.Queries.GetAllServices;

public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, IEnumerable<Service>>
{
    private readonly IServiceRepository _repo;

    public GetAllServicesQueryHandler(IServiceRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Service>> Handle(
        GetAllServicesQuery request,
        CancellationToken cancellationToken
        )
    {
        return await _repo.GetAllAsync();
    }
}
