using MediatR;
using AutoMapper;
using SpecializationService.Domain.Interfaces;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Application.CQRS.Commands.UpdateSpecialization;

public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand>
{
    private readonly ISpecializationRepository _repo;
    private readonly IMapper _mapper;

    public UpdateSpecializationCommandHandler(ISpecializationRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var spec = _mapper.Map<Specialization>(request);
        await _repo.UpdateAsync(spec);
        return Unit.Value;
    }
}
