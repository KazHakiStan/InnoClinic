using MediatR;
using ServicesService.Domain.Entities;

namespace ServicesService.Application.CQRS.Queries.GetAllServices;

public record GetAllServicesQuery : IRequest<IEnumerable<Service>>;
