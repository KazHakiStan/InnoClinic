using MediatR;

namespace SpecializationService.Application.CQRS.Commands.UpdateSpecialization;

public record UpdateSpecializationCommand(
    Guid Id,
    string SpecializationName,
    bool IsActive
    ) : IRequest;
