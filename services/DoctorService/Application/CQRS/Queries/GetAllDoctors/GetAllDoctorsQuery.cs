using MediatR;
using DoctorService.Domain.Entities;

namespace DoctorService.Application.CQRS.Queries.GetAllDoctors;

public record GetAllDoctorsQuery : IRequest<IEnumerable<Doctor>>;
