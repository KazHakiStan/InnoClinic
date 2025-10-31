using MediatR;
using DocumentsService.Domain.Entities;

namespace DocumentsService.Application.CQRS.Queries.GetDocumentById;

public record GetDocumentByIdQuery(Guid Id) : IRequest<Document?>;
