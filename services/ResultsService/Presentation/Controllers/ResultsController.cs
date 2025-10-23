using Microsoft.AspNetCore.Mvc;
using MediatR;
using ResultsService.Application.CQRS.Queries.GetAllResults;
using ResultsService.Application.CQRS.Commands.CreateResult;
using ResultsService.Application.CQRS.Queries.GetResultById;
using ResultsService.Application.CQRS.Commands.UpdateResult;
using ResultsService.Application.CQRS.Commands.DeleteResult;

namespace ResultsService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResultsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResultsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
      => Ok(await _mediator.Send(new GetAllResultsQuery()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetResultByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateResultCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateResultCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteResultCommand(id));
        return NoContent();
    }
}
