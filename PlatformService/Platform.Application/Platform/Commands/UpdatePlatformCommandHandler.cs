using Platform.Application.Common.Constants;
using Platform.Application.Common.Models;
using Platform.Core.Interfaces;

namespace Platform.Application.Platform.Commands;

public class UpdatePlatformCommandHandler(IPlatformRepository platformRepository) : IRequestHandler<UpdatePlatformCommand, CommonAPIResponse>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;

    public async Task<CommonAPIResponse> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await _platformRepository.GetByIdAsync(request.Id);

        if (entity == null) throw new Exception(ApplicationConstants.ItemNotFound);

        entity.Name = request.Name;
        entity.Publisher = request.Publisher;
        entity.Cost = request.Cost;

        await _platformRepository.UpdateAsync(entity, cancellationToken);

        return new CommonAPIResponse(ApplicationConstants.DataUpdatedSuccessfull, request);
    }
}
