namespace oMapBackend.Models;

public class Office
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    public List<OfficeMap> Maps { get; set; } = new();

    public List<Device> Devices { get; set; } = new();
}