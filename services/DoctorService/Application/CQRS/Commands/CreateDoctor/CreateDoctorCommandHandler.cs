using MediatR;
using AutoMapper;
using DoctorService.Application.Interfaces;
using DoctorService.Domain.Entities;

namespace DoctorService.Application.CQRS.Commands.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _repo;
    private readonly IMapper _mapper;

    public CreateDoctorCommandHandler(IDoctorRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<Doctor>(request);
        doctor.Id = Guid.NewGuid();
        await _repo.AddAsync(doctor);
        return doctor.Id;
    }
}
