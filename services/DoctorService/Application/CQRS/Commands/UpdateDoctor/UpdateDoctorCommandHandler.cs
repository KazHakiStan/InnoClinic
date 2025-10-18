using MediatR;
using AutoMapper;
using DoctorService.Domain.Interfaces;
using DoctorService.Domain.Entities;

namespace DoctorService.Application.CQRS.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
{
    private readonly IDoctorRepository _repo;
    private readonly IMapper _mapper;

    public UpdateDoctorCommandHandler(IDoctorRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<Doctor>(request);
        await _repo.UpdateAsync(doctor);
        return Unit.Value;
    }
}
