using AutoMapper;
using SpecializationService.Domain.Entities;
using SpecializationService.Application.CQRS.Commands.CreateSpecialization;
using SpecializationService.Application.CQRS.Commands.UpdateSpecialization;

namespace SpecializationService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateSpecializationCommand, Specialization>();
        CreateMap<UpdateSpecializationCommand, Specialization>();
    }
}


