namespace oMapBackend.DTO;
//TODO: This is wrong rn
public class UpdateDeviceDTO
{
    public string? Name { get; set; }
    public string? DeviceType { get; set; }
    public string? SerialNumber { get; set; }
    public string? Status { get; set; }
    public double? XPosition { get; set; }
    public double? YPosition { get; set; }
    public int? OfficeId { get; set; }
}