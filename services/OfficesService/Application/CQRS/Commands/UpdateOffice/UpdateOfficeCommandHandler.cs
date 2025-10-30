using MediatR;
using AutoMapper;
using OfficesService.Domain.Interfaces;
using OfficesService.Domain.Entities;

namespace OfficesService.Application.CQRS.Commands.UpdateOffice;

public class UpdateOfficeCommandHandler : IRequestHandler<UpdateOfficeCommand>
{
    private readonly IOfficeRepository _repo;
    private readonly IMapper _mapper;

    public UpdateOfficeCommandHandler(IOfficeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Office>(request);
        await _repo.UpdateAsync(account);
        return Unit.Value;
    }
}
