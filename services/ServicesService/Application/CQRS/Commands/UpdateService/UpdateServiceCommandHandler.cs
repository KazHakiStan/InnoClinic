using MediatR;
using AutoMapper;
using ServicesService.Domain.Interfaces;
using ServicesService.Domain.Entities;

namespace ServicesService.Application.CQRS.Commands.UpdateService;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IServiceRepository _repo;
    private readonly IMapper _mapper;

    public UpdateServiceCommandHandler(IServiceRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Service>(request);
        await _repo.UpdateAsync(service);
        return Unit.Value;
    }
}
