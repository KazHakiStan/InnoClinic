using MediatR;
using PhotoService.Domain.Entities;

namespace PhotoService.Application.CQRS.Queries.GetPhotoById;

public record GetPhotoByIdQuery(Guid Id) : IRequest<Photo?>;
