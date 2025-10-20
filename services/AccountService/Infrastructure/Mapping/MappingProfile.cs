using AutoMapper;
using AccountService.Domain.Entities;
using AccountService.Application.CQRS.Commands.CreateAccount;
using AccountService.Application.CQRS.Commands.UpdateAccount;

namespace AccountService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAccountCommand, Account>();
        CreateMap<UpdateAccountCommand, Account>();
    }
}



