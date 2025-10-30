using MediatR;

namespace ServicesService.Application.CQRS.Commands.UpdateService;

public record UpdateServiceCommand(
    Guid Id,
    Guid CategoryId,
    string ServiceName,
    decimal Price,
    Guid SpecializationId,
    bool IsActive
    ) : IRequest;
