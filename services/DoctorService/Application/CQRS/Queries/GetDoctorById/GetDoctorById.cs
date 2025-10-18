using MediatR;
using DoctorService.Domain.Entities;

namespace DoctorService.Application.CQRS.Queries.GetDoctorById;

public record GetDoctorByIdQuery(Guid Id) : IRequest<Doctor?>;
