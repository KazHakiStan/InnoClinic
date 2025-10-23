using MediatR;

namespace ResultsService.Application.CQRS.Commands.DeleteResult;

public record DeleteResultCommand(
    Guid Id
    ) : IRequest;
