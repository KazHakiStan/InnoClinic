using MediatR;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Application.CQRS.Queries.GetAllSpecializations;

public record GetAllSpecializationsQuery : IRequest<IEnumerable<Specialization>>;
