// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Domain

namespace OnDemandWatch.Domain.CloudProviders;

public class Azure: CloudProvider
{
    public Azure()
    {
        this.Id = new Guid("7df42755-70c4-4ad6-8916-c6a72e681a45");
        this.Name = "Windows Azure";
    }
    public override List<ServiceType>? GetServiceTypes()
    {
        throw new NotImplementedException();
    }
}