using MediatR;

namespace SpecializationService.Application.CQRS.Commands.DeleteSpecialization;

public record DeleteSpecializationCommand(Guid Id) : IRequest;
