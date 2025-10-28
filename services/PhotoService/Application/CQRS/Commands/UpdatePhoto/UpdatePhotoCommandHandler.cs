using MediatR;
using AutoMapper;
using PhotoService.Domain.Interfaces;
using PhotoService.Domain.Entities;

namespace PhotoService.Application.CQRS.Commands.UpdatePhoto;

public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand>
{
    private readonly IPhotoRepository _repo;
    private readonly IMapper _mapper;

    public UpdatePhotoCommandHandler(IPhotoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
    {
        var photo = _mapper.Map<Photo>(request);
        await _repo.UpdateAsync(photo);
        return Unit.Value;
    }
}
