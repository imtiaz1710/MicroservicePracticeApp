using Platform.Application.Common.Models;
using System.Text;
using System.Text.Json;

namespace Platform.API.SyncDataServices.Http
{
    public class CommandDataHttpClient: ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public CommandDataHttpClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task SendPlatformToCommand(PlatformDTO platform)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync(_config["CommandService"], httpContent);

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync platform to command ok");
            }
            else
            {
                Console.WriteLine("Fail to sync platform to command");
            }
        }
    }
}
