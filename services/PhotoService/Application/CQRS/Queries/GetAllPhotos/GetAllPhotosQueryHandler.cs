using MediatR;
using PhotoService.Domain.Interfaces;
using PhotoService.Domain.Entities;

namespace PhotoService.Application.CQRS.Queries.GetAllPhotos;

public class GetAllPhotosQueryHandler : IRequestHandler<GetAllPhotosQuery, IEnumerable<Photo>>
{
    private readonly IPhotoRepository _repo;

    public GetAllPhotosQueryHandler(IPhotoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Photo>> Handle(
        GetAllPhotosQuery request,
        CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
