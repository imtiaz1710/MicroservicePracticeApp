using Platform.Application.Common.Constants;
using Platform.Application.Common.Models;
using Platform.Core.Interfaces;

namespace Platform.Application.Platform.Queries;

public class GetAllPlatformQueryHandler(IPlatformRepository platformRepository) : IRequestHandler<GetAllPlatformQuery, CommonAPIResponse>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;

    public async Task<CommonAPIResponse> Handle(GetAllPlatformQuery request, CancellationToken cancellationToken)
    {
        var data = await _platformRepository.GetAllAsync();

        var res = data.Select(d => new PlatformDTO { Cost = d.Cost, Name = d.Name , Id = d.Id, Publisher = d.Publisher });

        return new CommonAPIResponse(ApplicationConstants.DataRetriveSuccessfull, res);
    }
}
