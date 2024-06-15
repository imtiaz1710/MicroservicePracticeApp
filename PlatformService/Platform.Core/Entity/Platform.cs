using System.ComponentModel.DataAnnotations;

namespace Platform.Core.Entity;

public class Platform : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Publisher { get; set; }
    public int Cost { get; set; }
}
