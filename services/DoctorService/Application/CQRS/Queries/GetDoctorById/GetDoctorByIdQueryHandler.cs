using MediatR;
using DoctorService.Domain.Interfaces;
using DoctorService.Domain.Entities;

namespace DoctorService.Application.CQRS.Queries.GetDoctorById;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor?>
{
    private readonly IDoctorRepository _repo;

    public GetDoctorByIdQueryHandler(IDoctorRepository repo) => _repo = repo;

    public async Task<Doctor?> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}
