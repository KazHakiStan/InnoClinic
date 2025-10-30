using MediatR;
using PhotoService.Domain.Interfaces;

namespace PhotoService.Application.CQRS.Commands.DeletePhoto;

public class DeletePhotoCommandHandler : IRequest<DeletePhotoCommand>
{
    private readonly IPhotoRepository _repo;

    public DeletePhotoCommandHandler(IPhotoRepository repo) => _repo = repo;

    public async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        var photo = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Photo {request.Id} not found.");
        await _repo.DeleteAsync(photo);
    }
}
