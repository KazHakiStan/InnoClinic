using AutoMapper;
using DoctorService.Domain.Entities;
using DoctorService.Application.CQRS.Commands.CreateDoctor;
using DoctorService.Application.CQRS.Commands.UpdateDoctor;

namespace DoctorService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>();
        CreateMap<UpdateDoctorCommand, Doctor>();
    }
}


