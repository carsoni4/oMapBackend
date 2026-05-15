namespace oMapBackend.Models;

public class OfficeMap
{
    public int Id { get; set; }

    public int OfficeId { get; set; }

    public Office? Office { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public int Width { get; set; }

    public int Height { get; set; }
}