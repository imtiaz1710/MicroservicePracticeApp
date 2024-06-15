using Platform.Application.Common.Constants;
using Platform.Application.Common.Models;
using Platform.Core.Interfaces;

namespace Platform.Application.Platform.Commands;

public class DeletePlatformCommandHandler(IPlatformRepository PlatformRepository) : IRequestHandler<DeletePlatformCommand, CommonAPIResponse>
{
    private readonly IPlatformRepository _PlatformRepository = PlatformRepository;

    public async Task<CommonAPIResponse> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await _PlatformRepository.GetByIdAsync(request.Id);

        if (entity == null) throw new Exception(ApplicationConstants.ItemNotFound);

        await _PlatformRepository.DeleteAsync(entity);

        return new CommonAPIResponse(ApplicationConstants.DataDeletedSuccessfull, entity);
    }
}
