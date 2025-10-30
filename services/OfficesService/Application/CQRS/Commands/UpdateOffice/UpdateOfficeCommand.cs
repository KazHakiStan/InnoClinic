using MediatR;

namespace OfficesService.Application.CQRS.Commands.UpdateOffice;

public record UpdateOfficeCommand(
    Guid Id,
    string Address,
    Guid PhotoId,
    string RegistryPhoneNumber,
    bool IsActive
    ) : IRequest;
