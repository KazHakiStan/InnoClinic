using MediatR;
using DocumentsService.Domain.Entities;
using DocumentsService.Domain.Interfaces;

namespace DocumentsService.Application.CQRS.Queries.GetDocumentById;

public class GetDocumentByIdQueryHandler : IRequestHandler<GetDocumentByIdQuery, Document?>
{
    private readonly IDocumentRepository _repo;

    public GetDocumentByIdQueryHandler(IDocumentRepository repo) => _repo = repo;

    public async Task<Document?> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}

