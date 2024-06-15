using Platform.Core.Entity;

namespace Platform.Infrustructure.Data;

public class PlatformDbContext : DbContext
{
    public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)
    {

    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        foreach (var item in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            switch (item.State)
            {
                case EntityState.Added:
                    item.Entity.Created = DateTime.Now;
                    //Todo
                    //
                    //item.Entity.CreatedBy = _currentUserService.UserId;
                    break;
                case EntityState.Modified:
                    item.Entity.LastModified = DateTime.Now;
                    //Todo
                    //
                    //item.Entity.LastUpdatedDate = _currentUserService.UserId;
                    break;
                default:
                    break;
            }
        }

        return base.SaveChangesAsync();
    }
    public DbSet<Core.Entity.Platform> platforms { get; set; }
}
