using AutoMapper;
using ResultsService.Application.CQRS.Commands.CreateResult;
using ResultsService.Application.CQRS.Commands.UpdateResult;
using ResultsService.Domain.Entities;

namespace ResultsService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateResultCommand, Result>();
        CreateMap<UpdateResultCommand, Result>();
    }
}
