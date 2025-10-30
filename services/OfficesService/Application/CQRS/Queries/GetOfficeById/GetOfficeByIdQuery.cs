using MediatR;
using OfficesService.Domain.Entities;

namespace OfficesService.Application.CQRS.Queries.GetOfficeById;

public record GetOfficeByIdQuery(Guid Id) : IRequest<Office?>;

