using Microsoft.AspNetCore.Mvc;
using MediatR;
using DoctorService.Application.CQRS.Commands.CreateDoctor;
using DoctorService.Application.CQRS.Queries.GetAllDoctors;

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
}
