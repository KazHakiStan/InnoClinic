using Microsoft.AspNetCore.Mvc;
using MediatR;
using PhotoService.Application.CQRS.Commands.CreatePhoto;
using PhotoService.Application.CQRS.Commands.UpdatePhoto;
using PhotoService.Application.CQRS.Commands.DeletePhoto;
using PhotoService.Application.CQRS.Queries.GetAllPhotos;
using PhotoService.Application.CQRS.Queries.GetPhotoById;

namespace PhotoService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PhotosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhotoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var photos = await _mediator.Send(new GetAllPhotosQuery());
        return Ok(photos);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var photo = await _mediator.Send(new GetPhotoByIdQuery(id));
        return photo is not null ? Ok(photo) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdatePhotoCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeletePhotoCommand(id));
        return NoContent();
    }
}
