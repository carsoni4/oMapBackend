namespace oMapBackend.Models;

public class Device
{
    public int Id { get; set; }

    public int OfficeId { get; set; }

    public Office? Office { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DeviceType { get; set; } = string.Empty;

    public string? SerialNumber { get; set; }

    public string Status { get; set; } = "Unknown";

    public double XPosition { get; set; }

    public double YPosition { get; set; }
}