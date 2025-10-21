using Microsoft.AspNetCore.Mvc;
using ReceptionistService.Domain.Entities;
using ReceptionistService.BusinessLogic.Interfaces;

namespace ReceptionistService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceptionistController : ControllerBase
{
    private readonly IReceptionistService _service;

    public ReceptionistController(IReceptionistService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var receptionist = await _service.GetByIdAsync(id);
        return receptionist is not null ? Ok(receptionist) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Receptionist receptionist)
    {
        await _service.CreateAsync(receptionist);
        return CreatedAtAction(nameof(GetById), new { id = receptionist.Id }, receptionist);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Receptionist receptionist)
    {
        if (id != receptionist.Id) return BadRequest("ID mismatch");
        await _service.UpdateAsync(receptionist);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
