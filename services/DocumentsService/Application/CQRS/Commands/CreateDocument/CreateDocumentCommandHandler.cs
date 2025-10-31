using MediatR;
using AutoMapper;
using DocumentsService.Domain.Interfaces;
using DocumentsService.Domain.Entities;

namespace DocumentsService.Application.CQRS.Commands.CreateDocument;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Guid>
{
    private readonly IDocumentRepository _repo;
    private readonly IMapper _mapper;

    public CreateDocumentCommandHandler(IDocumentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var doc = _mapper.Map<Document>(request);
        doc.Id = Guid.NewGuid();
        await _repo.AddAsync(doc);
        return doc.Id;
    }
}
