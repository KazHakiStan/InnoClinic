using Microsoft.AspNetCore.Mvc;
using MediatR;
using ServicesService.Application.CQRS.Commands.CreateService;
using ServicesService.Application.CQRS.Queries.GetAllServices;
using ServicesService.Application.CQRS.Queries.GetServiceById;
using ServicesService.Application.CQRS.Commands.UpdateService;
using ServicesService.Application.CQRS.Commands.DeleteService;

namespace AccountService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var services = await _mediator.Send(new GetAllServicesQuery());
        return Ok(services);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var service = await _mediator.Send(new GetServiceByIdQuery(id));
        return service is not null ? Ok(service) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateServiceCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteServiceCommand(id));
        return NoContent();
    }
}

