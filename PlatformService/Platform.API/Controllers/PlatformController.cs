using Platform.API.SyncDataServices.Http;
using Platform.Application.Common.Models;
using Platform.Application.Platform.Commands;
using Platform.Application.Platform.Queries;

namespace Platform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController(IMediator mediator, ILogger<PlatformController> logger, ICommandDataClient commandDataClient) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<PlatformController> _logger = logger;
    private readonly ICommandDataClient _commandDataClient = commandDataClient;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Platform fetch starting...");

        var response = await _mediator.Send(new GetAllPlatformQuery());

        _logger.LogInformation("Successfully fetch the Platform...");

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePlatformCommand Platform)
    {
        var response = await _mediator.Send(Platform);

        try
        {
            await _commandDataClient.SendPlatformToCommand(response.data);
        }
        catch (Exception)
        {
            _logger.LogError("Can not send data from platform to command");
        }

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdatePlatformCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeletePlatformCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}
