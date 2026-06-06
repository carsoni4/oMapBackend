namespace oMapBackend.Models;

public class Office
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Device> Devices { get; set; } = new();
}