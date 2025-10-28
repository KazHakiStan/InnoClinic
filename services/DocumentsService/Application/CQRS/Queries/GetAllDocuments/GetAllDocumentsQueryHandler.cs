using MediatR;
using DocumentsService.Domain.Entities;
using DocumentsService.Domain.Interfaces;

namespace DocumentsService.Application.CQRS.Queries.GetAllDocuments;

public class GetAllDocumentsQueryHandler : IRequestHandler<GetAllDocumentsQuery, IEnumerable<Document>>
{
    private readonly IDocumentRepository _repo;

    public GetAllDocumentsQueryHandler(IDocumentRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Document>> Handle(
        GetAllDocumentsQuery request,
        CancellationToken cancellationToken
        )
    {
        return await _repo.GetAllAsync();
    }
}
