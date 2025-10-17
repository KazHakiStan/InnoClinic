using AutoMapper;
using PatientService.Application.DTOs;
using PatientService.Domain.Entities;

namespace PatientService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDto>();

        CreateMap<PatientDto, Patient>();
    }
}
