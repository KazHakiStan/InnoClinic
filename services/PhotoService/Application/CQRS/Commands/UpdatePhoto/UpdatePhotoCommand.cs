using MediatR;

namespace PhotoService.Application.CQRS.Commands.UpdatePhoto;

public record UpdatePhotoCommand(
    Guid Id,
    string Url
    ) : IRequest;
