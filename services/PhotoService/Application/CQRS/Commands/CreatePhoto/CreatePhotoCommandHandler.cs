using MediatR;
using AutoMapper;
using PhotoService.Domain.Interfaces;
using PhotoService.Domain.Entities;

namespace PhotoService.Application.CQRS.Commands.CreatePhoto;

public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, Guid>
{
    private readonly IPhotoRepository _repo;
    private readonly IMapper _mapper;

    public CreatePhotoCommandHandler(IPhotoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
    {
        var photo = _mapper.Map<Photo>(request);
        photo.Id = Guid.NewGuid();
        await _repo.AddAsync(photo);
        return photo.Id;
    }
}
