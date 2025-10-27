using MediatR;
using AutoMapper;
using ServicesService.Domain.Interfaces;
using ServicesService.Domain.Entities;

namespace ServicesService.Application.CQRS.Commands.CreateService;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Guid>
{
    private readonly IServiceRepository _repo;
    private readonly IMapper _mapper;

    public CreateServiceCommandHandler(IServiceRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Service>(request);
        account.Id = Guid.NewGuid();
        await _repo.AddAsync(account);
        return account.Id;
    }
}
