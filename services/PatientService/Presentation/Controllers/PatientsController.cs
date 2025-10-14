using Microsoft.AspNetCore.Mvc;
using PatientService.Domain.Entities;
using PatientService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PatientService.Application.DTOs;
using PatientService.Application.Interfaces;

namespace PatientService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientsController(IPatientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var patient = await _service.GetByIdAsync(id);
        return patient is null ? NotFound() : Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PatientDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, dto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, PatientDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? Ok(dto) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
