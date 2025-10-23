using MediatR;
using ResultsService.Domain.Interfaces;
using ResultsService.Domain.Entities;

namespace ResultsService.Application.CQRS.Queries.GetAllResults;

public class GetAllResultsQueryHandler : IRequestHandler<GetAllResultsQuery, IEnumerable<Result>>
{
    private readonly IResultRepository _repo;

    public GetAllResultsQueryHandler(IResultRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Result>> Handle(GetAllResultsQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
