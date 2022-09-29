// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Domain

namespace OnDemandWatch.Domain.CloudProviders;

public class Google: CloudProvider
{
    public Google()
    {
        Id =  Guid.Parse("98ee2db7-f58e-449b-a07a-a7e74c03dcf3");
        Name = "Google Cloud";
    }

    public override List<ServiceType>? GetServiceTypes()
    {
        throw new NotImplementedException();
    }
}