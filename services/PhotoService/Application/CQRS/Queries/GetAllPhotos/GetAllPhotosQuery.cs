using MediatR;
using PhotoService.Domain.Entities;

namespace PhotoService.Application.CQRS.Queries.GetAllPhotos;

public record GetAllPhotosQuery : IRequest<IEnumerable<Photo>>;
