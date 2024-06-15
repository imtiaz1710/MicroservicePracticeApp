using Platform.Application.Common.Constants;
using Platform.Application.Common.Models;
using Platform.Core.Interfaces;

namespace Platform.Application.Platform.Commands;

public class CreatePlatformCommandHandler(IPlatformRepository PlatformRepository) :
    IRequestHandler<CreatePlatformCommand, CommonAPIResponse>
{
    private readonly IPlatformRepository _PlatformRepository = PlatformRepository;

    public async Task<CommonAPIResponse> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platformEntity = new Core.Entity.Platform
        {
            Cost = request.Cost,
            Name = request.Name,
            Publisher = request.Publisher
        };

        var response = await _PlatformRepository.AddAsync(platformEntity);

        return new CommonAPIResponse(data: response, message: ApplicationConstants.DataCreatedSuccessfull);
    }
}
