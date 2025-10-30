
using Microsoft.AspNetCore.Mvc;
using MediatR;
using OfficesService.Application.CQRS.Commands.CreateOffice;
using OfficesService.Application.CQRS.Queries.GetAllOffices;
using OfficesService.Application.CQRS.Queries.GetOfficeById;
using OfficesService.Application.CQRS.Commands.UpdateOffice;
using OfficesService.Application.CQRS.Commands.DeleteOffice;

namespace OfficesService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficesController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfficesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOfficeCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var offices = await _mediator.Send(new GetAllOfficesQuery());
        return Ok(offices);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var office = await _mediator.Send(new GetOfficeByIdQuery(id));
        return office is not null ? Ok(office) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateOfficeCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteOfficeCommand(id));
        return NoContent();
    }
}
