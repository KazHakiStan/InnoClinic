using MediatR;

namespace AccountService.Application.CQRS.Commands.DeleteAccount;

public record DeleteAccountCommand(Guid Id) : IRequest;

