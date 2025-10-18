using Microsoft.AspNetCore.Mvc;
using MediatR;
using DoctorService.Application.CQRS.Commands.CreateDoctor;
using DoctorService.Application.CQRS.Commands.UpdateDoctor;
using DoctorService.Application.CQRS.Commands.DeleteDoctor;
using DoctorService.Application.CQRS.Queries.GetAllDoctors;
using DoctorService.Application.CQRS.Queries.GetDoctorById;

namespace DoctorService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await _mediator.Send(new GetAllDoctorsQuery());
        return Ok(doctors);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doctor = await _mediator.Send(new GetDoctorByIdQuery(id));
        return doctor is not null ? Ok(doctor) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateDoctorCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteDoctorCommand(id));
        return NoContent();
    }
}
