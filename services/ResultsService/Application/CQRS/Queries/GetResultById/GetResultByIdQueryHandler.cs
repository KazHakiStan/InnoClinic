using MediatR;
using ResultsService.Domain.Entities;
using ResultsService.Domain.Interfaces;

namespace ResultsService.Application.CQRS.Queries.GetResultById;

public class GetResultByIdQueryHandler : IRequestHandler<GetResultByIdQuery, Result?>
{
    private readonly IResultRepository _repo;

    public GetResultByIdQueryHandler(IResultRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result?> Handle(GetResultByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}
