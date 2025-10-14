using Microsoft.AspNetCore.Mvc;
using PatientService.Domain.Entities;
using PatientService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PatientService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly PatientDbContext _context;

    public PatientsController(PatientDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _context.Patients.ToListAsync();
        return Ok(patients);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
            return NotFound($"Patient with id {id} not found.");

        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Patient patient)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        patient.Id = Guid.NewGuid();
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Patient updatedPatient)
    {
        if (id != updatedPatient.Id)
            return BadRequest("ID in URL and body do not match.");

        var existing = await _context.Patients.FindAsync(id);
        if (existing == null)
            return NotFound($"Patient with id {id} not found.");

        existing.FirstName = updatedPatient.FirstName;
        existing.LastName = updatedPatient.LastName;
        existing.MiddleName = updatedPatient.MiddleName;
        existing.DateOfBirth = updatedPatient.DateOfBirth;
        existing.IsLinkedToAccount = updatedPatient.IsLinkedToAccount;

        _context.Patients.Update(existing);
        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
            return NotFound($"Patient with id {id} not found.");

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
