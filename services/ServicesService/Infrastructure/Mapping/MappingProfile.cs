using AutoMapper;
using ServicesService.Application.CQRS.Commands.CreateService;
using ServicesService.Application.CQRS.Commands.UpdateService;
using ServicesService.Domain.Entities;

namespace ServicesService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateServiceCommand, Service>();
        CreateMap<UpdateServiceCommand, Service>();
    }
}



