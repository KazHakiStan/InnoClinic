using MediatR;
using DocumentsService.Domain.Interfaces;

namespace DocumentsService.Application.CQRS.Commands.DeleteDocument;

public class DeleteDocumentCommandHandler : IRequest<DeleteDocumentCommand>
{
    private readonly IDocumentRepository _repo;

    public DeleteDocumentCommandHandler(IDocumentRepository repo) => _repo = repo;

    public async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        var doc = await _repo.GetByIdAsync(request.Id)
          ?? throw new KeyNotFoundException($"Doctor {request.Id} not found.");
        await _repo.DeleteAsync(doc);
    }
}

