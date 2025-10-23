using MediatR;

namespace ResultsService.Application.CQRS.Commands.CreateResult;

public record CreateResultCommand(
    string Complaints,
    string Conclusion,
    string Recommendations,
    Guid AppointmentId
    ) : IRequest<Guid>;
