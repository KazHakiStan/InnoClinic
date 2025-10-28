using MediatR;

namespace DocumentsService.Application.CQRS.Commands.DeleteDocument;

public record DeleteDocumentCommand(Guid Id) : IRequest;

