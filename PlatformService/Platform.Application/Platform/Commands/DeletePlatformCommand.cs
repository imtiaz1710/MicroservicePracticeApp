using Platform.Application.Common.Models;

namespace Platform.Application.Platform.Commands;
public class DeletePlatformCommand : IRequest<CommonAPIResponse>
{
    public Guid Id { get; set; }
}
