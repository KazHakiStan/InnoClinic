using MediatR;
using AutoMapper;
using SpecializationService.Domain.Interfaces;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Application.CQRS.Commands.CreateSpecialization;

public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, Guid>
{
    private readonly ISpecializationRepository _repo;
    private readonly IMapper _mapper;

    public CreateSpecializationCommandHandler(ISpecializationRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var spec = _mapper.Map<Specialization>(request);
        spec.Id = Guid.NewGuid();
        await _repo.AddAsync(spec);
        return spec.Id;
    }
}
