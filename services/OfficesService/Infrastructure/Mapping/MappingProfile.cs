using AutoMapper;
using OfficesService.Domain.Entities;
using OfficesService.Application.CQRS.Commands.CreateOffice;
using OfficesService.Application.CQRS.Commands.UpdateOffice;

namespace OfficesService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOfficeCommand, Office>();
        CreateMap<UpdateOfficeCommand, Office>();
    }
}



