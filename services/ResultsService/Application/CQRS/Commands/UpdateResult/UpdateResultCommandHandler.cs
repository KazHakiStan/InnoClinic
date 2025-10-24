using AutoMapper;
using MediatR;
using ResultsService.Domain.Entities;
using ResultsService.Domain.Interfaces;

namespace ResultsService.Application.CQRS.Commands.UpdateResult;

public class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommand>
{
    private readonly IResultRepository _repo;
    private readonly IMapper _mapper;

    public UpdateResultCommandHandler(IResultRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Result>(request);
        await _repo.UpdateAsync(result);
        return Unit.Value;
    }
}
