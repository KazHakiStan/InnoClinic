using AutoMapper;
using DoctorService.Domain.Entities;
using DoctorService.Application.CQRS.Commands.CreateDoctor;

namespace DoctorService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>();
    }
}


