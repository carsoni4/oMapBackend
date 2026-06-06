using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oMapBackend.Models;
using oMapBackend.Data;
using Microsoft.AspNetCore.Authorization;


namespace oMapBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficeController : ControllerBase
{

    private readonly AppDbContext _database;
    public OfficeController(AppDbContext database)
    {
        _database = database;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetOfficeDevices(int officeId)
    {
        var office = await _database.Offices.FirstOrDefaultAsync(o => o.Id == officeId);
        if (office == null)
            return BadRequest();

        return Ok(office.Devices);
    }
}