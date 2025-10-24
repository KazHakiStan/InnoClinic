using MediatR;
using ResultsService.Domain.Interfaces;

namespace ResultsService.Application.CQRS.Commands.DeleteResult;

public class DeleteResultCommandHandler : IRequestHandler<DeleteResultCommand, Unit>
{
    private readonly IResultRepository _repo;

    public DeleteResultCommandHandler(IResultRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(DeleteResultCommand request, CancellationToken cancellationToken)
    {
        var result = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Result {request.Id} not found.");
        await _repo.DeleteAsync(result);
        return Unit.Value;
    }
}
