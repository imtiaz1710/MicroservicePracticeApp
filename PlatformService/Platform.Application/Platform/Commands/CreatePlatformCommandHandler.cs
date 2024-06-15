using Platform.Application.Common.Constants;
using Platform.Application.Common.Models;
using Platform.Core.Interfaces;

namespace Platform.Application.Platform.Commands;

public class CreatePlatformCommandHandler(IPlatformRepository PlatformRepository) :
    IRequestHandler<CreatePlatformCommand, CommonAPIResponse<PlatformDTO>>
{
    private readonly IPlatformRepository _PlatformRepository = PlatformRepository;

    public async Task<CommonAPIResponse<PlatformDTO>> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platformEntity = new Core.Entity.Platform
        {
            Cost = request.Cost,
            Name = request.Name,
            Publisher = request.Publisher
        };

        var platform = await _PlatformRepository.AddAsync(platformEntity);

        var PlatformDTO = new PlatformDTO { Cost = platform.Cost, Name = platform.Name, Id = platform.Id, Publisher = platform.Publisher };
        return new CommonAPIResponse<PlatformDTO>(data: PlatformDTO, message: ApplicationConstants.DataCreatedSuccessfull);
    }
}
