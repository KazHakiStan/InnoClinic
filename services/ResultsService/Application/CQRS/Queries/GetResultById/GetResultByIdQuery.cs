using MediatR;
using ResultsService.Domain.Entities;

namespace ResultsService.Application.CQRS.Queries.GetResultById;

public record GetResultByIdQuery(Guid Id) : IRequest<Result?>;
