using Platform.Application.Common.Models;

namespace Platform.Application.Platform.Commands;

public class CreatePlatformCommand : IRequest<CommonAPIResponse<PlatformDTO>>
{
    public required string Name { get; set; }
    public required string Publisher { get; set; }
    public int Cost { get; set; }
}
