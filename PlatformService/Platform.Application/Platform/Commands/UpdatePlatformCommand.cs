using Platform.Application.Common.Models;

namespace Platform.Application.Platform.Commands;

public class UpdatePlatformCommand : IRequest<CommonAPIResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Publisher { get; set; }
    public int Cost { get; set; }
}
