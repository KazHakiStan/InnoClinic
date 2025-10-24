using MediatR;

namespace DoctorService.Application.CQRS.Commands.UpdateDoctor;

public record UpdateDoctorCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    DateTime DateOfBirth,
    Guid AccountId,
    int CareerStartYear,
    string Status
    ) : IRequest;
