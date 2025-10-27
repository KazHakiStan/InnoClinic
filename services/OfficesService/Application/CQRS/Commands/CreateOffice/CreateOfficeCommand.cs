using MediatR;

namespace OfficesService.Application.CQRS.Commands.CreateOffice;

public record CreateOfficeCommand(
    string Address,
    Guid PhotoId,
    string RegistryPhoneNumber,
    bool IsActive
    ) : IRequest<Guid>;
