using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oMapBackend.Data;
using oMapBackend.Models;

namespace oMapBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DevicesController : ControllerBase
{
    private readonly AppDbContext _database;

    public DevicesController(AppDbContext database)
    {
        _database = database;
    }

    [HttpGet]
    public async Task<ActionResult<List<Device>>> GetDevices()
    {       
        Console.WriteLine("Fetching all devices...");
        return await _database.Devices.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Device>> GetDevice(int id)
    {
        var device = await _database.Devices.FindAsync(id);
        if (device == null)
        {
            return NotFound();
        }

        return device;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(int id)
    {
        var device = await _database.Devices.FindAsync(id);
        if (device == null)
        {
            return NotFound();
        }

        _database.Devices.Remove(device);
        await _database.SaveChangesAsync();

        return NoContent();
    }
}
