using MediatR;

namespace PhotoService.Application.CQRS.Commands.DeletePhoto;

public record DeletePhotoCommand(Guid Id) : IRequest;
