using MediatR;
using AutoMapper;
using DocumentsService.Domain.Interfaces;
using DocumentsService.Domain.Entities;

namespace DocumentsService.Application.CQRS.Commands.UpdateDocument;

public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand>
{
    private readonly IDocumentRepository _repo;
    private readonly IMapper _mapper;

    public UpdateDocumentCommandHandler(IDocumentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
    {
        var doc = _mapper.Map<Document>(request);
        await _repo.UpdateAsync(doc);
        return Unit.Value;
    }
}
