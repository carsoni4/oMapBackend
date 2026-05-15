using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oMapBackend.Data;
using oMapBackend.Models;

namespace oMapBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficesController : ControllerBase
{
    private readonly AppDbContext _context;

    public OfficesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Office>>> GetOffices()
    {
        return await _context.Offices
            .Include(o => o.Maps)
            .Include(o => o.Devices)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Office>> GetOffice(int id)
    {
        var office = await _context.Offices
            .Include(o => o.Maps)
            .Include(o => o.Devices)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (office == null)
        {
            return NotFound();
        }

        return office;
    }

    [HttpPost]
    public async Task<ActionResult<Office>> CreateOffice(Office office)
    {
        _context.Offices.Add(office);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOffice), new { id = office.Id }, office);
    }
}