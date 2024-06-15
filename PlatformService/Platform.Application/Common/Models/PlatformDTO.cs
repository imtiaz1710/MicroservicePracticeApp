namespace Platform.Application.Common.Models;

public class PlatformDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Publisher { get; set; }
    public int Cost { get; set; }
}
