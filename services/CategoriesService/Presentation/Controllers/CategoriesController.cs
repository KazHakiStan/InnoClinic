using Microsoft.AspNetCore.Mvc;
using MediatR;
using CategoryService.Application.CQRS.Commands.CreateCategory;
using CategoryService.Application.CQRS.Commands.UpdateCategory;
using CategoryService.Application.CQRS.Commands.DeleteCategory;
using CategoryService.Application.CQRS.Queries.GetAllCategories;
using CategoryService.Application.CQRS.Queries.GetCategoryById;

namespace CategoryService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(categories);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(id));
        return category is not null ? Ok(category) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateCategoryCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}
