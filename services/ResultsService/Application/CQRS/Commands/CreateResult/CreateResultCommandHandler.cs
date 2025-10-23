using AutoMapper;
using MediatR;
using ResultsService.Domain.Entities;
using ResultsService.Domain.Interfaces;

namespace ResultsService.Application.CQRS.Commands.CreateResult;

public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, Guid>
{
    private readonly IResultRepository _repo;
    private readonly IMapper _mapper;

    public CreateResultCommandHandler(IResultRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateResultCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Result>(request);
        result.Id = Guid.NewGuid();
        await _repo.CreateAsync(result);
        return result.Id;
    }
}
