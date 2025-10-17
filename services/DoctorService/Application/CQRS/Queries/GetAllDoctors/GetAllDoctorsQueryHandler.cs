using MediatR;
using DoctorService.Application.Interfaces;
using DoctorService.Domain.Entities;

namespace DoctorService.Application.CQRS.Queries.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<Doctor>>
{
    private readonly IDoctorRepository _repo;

    public GetAllDoctorsQueryHandler(IDoctorRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Doctor>> Handle(
        GetAllDoctorsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
