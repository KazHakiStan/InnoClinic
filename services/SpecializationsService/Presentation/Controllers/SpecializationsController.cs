using Microsoft.AspNetCore.Mvc;
using MediatR;
using SpecializationService.Application.CQRS.Commands.CreateSpecialization;
using SpecializationService.Application.CQRS.Commands.UpdateSpecialization;
using SpecializationService.Application.CQRS.Commands.DeleteSpecialization;
using SpecializationService.Application.CQRS.Queries.GetAllSpecializations;
using SpecializationService.Application.CQRS.Queries.GetSpecializationById;

namespace SpecializationService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecializationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecializationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpecializationCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var specs = await _mediator.Send(new GetAllSpecializationsQuery());
        return Ok(specs);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var spec = await _mediator.Send(new GetSpecializationByIdQuery(id));
        return spec is not null ? Ok(spec) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateSpecializationCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteSpecializationCommand(id));
        return NoContent();
    }
}
