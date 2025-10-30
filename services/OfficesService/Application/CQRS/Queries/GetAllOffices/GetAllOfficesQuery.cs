using MediatR;
using OfficesService.Domain.Entities;

namespace OfficesService.Application.CQRS.Queries.GetAllOffices;

public record GetAllOfficesQuery : IRequest<IEnumerable<Office>>;
