using AutoMapper;
using CategoryService.Domain.Entities;
using CategoryService.Application.CQRS.Commands.CreateCategory;
using CategoryService.Application.CQRS.Commands.UpdateCategory;

namespace CategoryService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}


