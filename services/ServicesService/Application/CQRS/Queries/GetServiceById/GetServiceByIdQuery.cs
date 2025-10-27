using MediatR;
using ServicesService.Domain.Entities;

namespace ServicesService.Application.CQRS.Queries.GetServiceById;

public record GetServiceByIdQuery(Guid Id) : IRequest<Service?>;
