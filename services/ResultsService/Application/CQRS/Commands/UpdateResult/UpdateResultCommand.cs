using MediatR;

namespace ResultsService.Application.CQRS.Commands.UpdateResult;

public record UpdateResultCommand(
    Guid Id,
    string Complaints,
    string Conclusion,
    string Recommendations,
    Guid AppointmentId
    ) : IRequest;
