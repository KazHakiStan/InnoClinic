using MediatR;
using ResultsService.Domain.Entities;

namespace ResultsService.Application.CQRS.Queries.GetAllResults;

public record GetAllResultsQuery : IRequest<IEnumerable<Result>>;
