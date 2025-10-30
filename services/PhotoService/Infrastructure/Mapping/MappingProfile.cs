using AutoMapper;
using PhotoService.Domain.Entities;
using PhotoService.Application.CQRS.Commands.CreatePhoto;
using PhotoService.Application.CQRS.Commands.UpdatePhoto;

namespace PhotoService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePhotoCommand, Photo>();
        CreateMap<UpdatePhotoCommand, Photo>();
    }
}


