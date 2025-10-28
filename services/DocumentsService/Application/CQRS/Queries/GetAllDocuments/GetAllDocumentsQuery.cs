using MediatR;
using DocumentsService.Domain.Entities;

namespace DocumentsService.Application.CQRS.Queries.GetAllDocuments;

public record GetAllDocumentsQuery : IRequest<IEnumerable<Document>>;
