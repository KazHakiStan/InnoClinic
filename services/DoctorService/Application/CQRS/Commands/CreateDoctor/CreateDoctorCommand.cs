using MediatR;

namespace DoctorService.Application.CQRS.Commands.CreateDoctor;

public record CreateDoctorCommand(string FirstName, string LastName, string? MiddleName, DateTime DateOfBirth, int CareerStartYear, string Status) : IRequest<Guid>;
