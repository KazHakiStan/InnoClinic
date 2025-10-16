using AutoMapper;
using PatientService.Application.DTOs;
using PatientService.Domain.Entities;

namespace PatientService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDto>();

        CreateMap<PatientDto, Patient>();
    }
}
