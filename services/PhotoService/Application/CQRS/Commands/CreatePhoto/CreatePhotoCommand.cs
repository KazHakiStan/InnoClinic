using MediatR;

namespace PhotoService.Application.CQRS.Commands.CreatePhoto;

public record CreatePhotoCommand(
    string Url
    ) : IRequest<Guid>;
