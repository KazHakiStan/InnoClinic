using Microsoft.AspNetCore.Mvc;
using MediatR;
using AccountService.Application.CQRS.Commands.CreateAccount;
using AccountService.Application.CQRS.Queries.GetAllAccounts;
using AccountService.Application.CQRS.Queries.GetAccountById;
using AccountService.Application.CQRS.Commands.UpdateAccount;
using AccountService.Application.CQRS.Commands.DeleteAccount;

namespace AccountService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _mediator.Send(new GetAllAccountsQuery());
        return Ok(accounts);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var account = await _mediator.Send(new GetAccountByIdQuery(id));
        return account is not null ? Ok(account) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateAccountCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteAccountCommand(id));
        return NoContent();
    }
}

