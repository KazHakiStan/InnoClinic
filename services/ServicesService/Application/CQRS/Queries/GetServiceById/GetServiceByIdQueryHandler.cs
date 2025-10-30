using MediatR;
using ServicesService.Domain.Entities;
using ServicesService.Domain.Interfaces;

namespace ServicesService.Application.CQRS.Queries.GetServiceById;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Service?>
{
    private readonly IServiceRepository _repo;

    public GetServiceByIdQueryHandler(IServiceRepository repo) => _repo = repo;

    public async Task<Service?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}

