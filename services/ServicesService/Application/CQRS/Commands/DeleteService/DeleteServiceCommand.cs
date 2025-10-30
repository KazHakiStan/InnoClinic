using MediatR;

namespace ServicesService.Application.CQRS.Commands.DeleteService;

public record DeleteServiceCommand(Guid Id) : IRequest;

