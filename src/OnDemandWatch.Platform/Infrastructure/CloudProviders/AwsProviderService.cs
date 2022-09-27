// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Platform

using OnDemandWatch.Domain.CloudProviders;
using OnDemandWatch.Domain.CloudProviders.Filters;

namespace OnDemandWatch.Platform.Infrastructure.CloudProviders;

public class AwsProviderService: ICloudProviderService
{
    public Task<List<Service>> GetServices(ServiceFilter filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Service> GetServiceDetail(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateResourceThrougput(Service service, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}