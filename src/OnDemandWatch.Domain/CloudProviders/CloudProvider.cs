using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.CloudProviders;

public abstract class CloudProvider : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public virtual List<ServiceType>? ServiceTypes { internal get; set; }
    public abstract List<ServiceType>? GetServiceTypes();
}