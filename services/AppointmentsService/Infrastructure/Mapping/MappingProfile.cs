using AppointmentsService.Application.DTOs;
using AppointmentsService.Domain.Entities;
using AutoMapper;

namespace AppointmentsService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<AppointmentDto, Appointment>();
    }
}
