using Platform.Application.Common.Models;
using Platform.Application.Platform.Commands;
using Platform.Application.Platform.Queries;

namespace Platform.API.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformDTO platform);
    }
}
