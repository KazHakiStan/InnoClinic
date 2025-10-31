using MediatR;

namespace DocumentsService.Application.CQRS.Commands.CreateDocument;

public record CreateDocumentCommand(
    string Url,
    Guid ResultId
    ) : IRequest<Guid>;
