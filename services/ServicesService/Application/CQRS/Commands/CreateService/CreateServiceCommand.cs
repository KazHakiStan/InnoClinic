using MediatR;

namespace ServicesService.Application.CQRS.Commands.CreateService;

public record CreateServiceCommand(
    Guid CategoryId,
    string ServiceName,
    decimal Price,
    Guid SpecializationId,
    bool IsActive
    ) : IRequest<Guid>;
