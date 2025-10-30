using MediatR;

namespace OfficesService.Application.CQRS.Commands.DeleteOffice;

public record DeleteOfficeCommand(Guid Id) : IRequest;

