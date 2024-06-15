using Platform.Application.Common.Models;
using System.Text;
using System.Text.Json;

namespace Platform.API.SyncDataServices.Http
{
    public class CommandDataHttpClient: ICommandDataClient
    {
        private readonly HttpClient _httpClient;

        public CommandDataHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendPlatformToCommand(PlatformDTO platform)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync("https://localhost:44389/api/c/Platform", httpContent);

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
