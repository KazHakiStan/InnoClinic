using Microsoft.AspNetCore.Mvc;
using MediatR;
using DocumentsService.Application.CQRS.Commands.CreateDocument;
using DocumentsService.Application.CQRS.Queries.GetAllDocuments;
using DocumentsService.Application.CQRS.Queries.GetDocumentById;
using DocumentsService.Application.CQRS.Commands.UpdateDocument;
using DocumentsService.Application.CQRS.Commands.DeleteDocument;

namespace DocumentsService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDocumentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var docs = await _mediator.Send(new GetAllDocumentsQuery());
        return Ok(docs);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doc = await _mediator.Send(new GetDocumentByIdQuery(id));
        return doc is not null ? Ok(doc) : NotFound();
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Update(Guid id, UpdateDocumentCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _mediator.Send(new DeleteDocumentCommand(id));
        return NoContent();
    }
}

