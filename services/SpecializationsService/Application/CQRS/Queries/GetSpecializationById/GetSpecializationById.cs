using MediatR;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Application.CQRS.Queries.GetSpecializationById;

public record GetSpecializationByIdQuery(Guid Id) : IRequest<Specialization?>;
