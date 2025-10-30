using MediatR;

namespace SpecializationService.Application.CQRS.Commands.CreateSpecialization;

public record CreateSpecializationCommand(
    string SpecializationName,
    bool IsActive
    ) : IRequest<Guid>;
