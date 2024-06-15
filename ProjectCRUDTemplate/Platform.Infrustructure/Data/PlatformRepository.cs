using Platform.Core.Interfaces;
namespace Platform.Infrustructure.Data;
public class PlatformRepository : BaseRepository<Core.Entity.Platform>, IPlatformRepository
{
    public PlatformRepository(PlatformDbContext dbContext) : base(dbContext)
    {
    }
}
