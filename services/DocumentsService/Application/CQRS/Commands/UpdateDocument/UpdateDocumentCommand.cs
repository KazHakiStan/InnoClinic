using MediatR;

namespace DocumentsService.Application.CQRS.Commands.UpdateDocument;

public record UpdateDocumentCommand(
    Guid Id,
    string Url,
    Guid ResultId
    ) : IRequest;
