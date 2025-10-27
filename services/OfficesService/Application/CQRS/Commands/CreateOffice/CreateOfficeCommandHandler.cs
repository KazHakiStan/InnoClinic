using MediatR;
using AutoMapper;
using OfficesService.Domain.Interfaces;
using OfficesService.Domain.Entities;

namespace OfficesService.Application.CQRS.Commands.CreateOffice;

public class CreateAccountCommandHandler : IRequestHandler<CreateOfficeCommand, Guid>
{
    private readonly IOfficeRepository _repo;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IOfficeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Office>(request);
        account.Id = Guid.NewGuid();
        await _repo.AddAsync(account);
        return account.Id;
    }
}
