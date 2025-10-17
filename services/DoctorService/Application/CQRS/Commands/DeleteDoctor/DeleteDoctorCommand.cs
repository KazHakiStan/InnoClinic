using MediatR;

namespace DoctorService.Application.CQRS.Commands.DeleteDoctor;

public record DeleteDoctorCommand(Guid Id) : IRequest;
