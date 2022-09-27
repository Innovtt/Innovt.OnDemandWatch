using Innovt.Core.Utilities;
using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.CloudProviders;

public class CloudProvider : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public virtual List<ServiceType>? ServiceTypes { get; set; }
}