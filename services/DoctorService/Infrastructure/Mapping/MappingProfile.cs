using AutoMapper;
using DoctorService.Domain.Entities;
using DoctorService.Application.CQRS.Commands.CreateDoctor;

namespace DoctorService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>();
    }
}


