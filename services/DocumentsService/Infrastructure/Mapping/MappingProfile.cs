using AutoMapper;
using DocumentsService.Application.CQRS.Commands.CreateDocument;
using DocumentsService.Application.CQRS.Commands.UpdateDocument;
using DocumentsService.Domain.Entities;

namespace DocumentsService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDocumentCommand, Document>();
        CreateMap<UpdateDocumentCommand, Document>();
    }
}



