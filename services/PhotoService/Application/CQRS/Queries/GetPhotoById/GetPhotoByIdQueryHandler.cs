using MediatR;
using PhotoService.Domain.Interfaces;
using PhotoService.Domain.Entities;

namespace PhotoService.Application.CQRS.Queries.GetPhotoById;

public class GetPhotoByIdQueryHandler : IRequestHandler<GetPhotoByIdQuery, Photo?>
{
    private readonly IPhotoRepository _repo;

    public GetPhotoByIdQueryHandler(IPhotoRepository repo) => _repo = repo;

    public async Task<Photo?> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}
