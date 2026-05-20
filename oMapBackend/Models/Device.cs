using System.Drawing;

namespace oMapBackend.Models;

/// <summary>
/// This should only be used for required fields 
/// All other fields should be in another customizable class
/// </summary>
public class Device
{
    public int Id { get; set; }
    public required string Name { get; set;}
    public required string DeviceType { get; set; }
    public required int X { get; set; }
    public required int Y { get; set; }
    public required string Color { get; set; }
    public required int OfficeId { get; set; }
    public Office? Office { get; set; }
}