using OnDemandWatch.Domain.CloudProviders.Filters;

namespace OnDemandWatch.Domain.CloudProviders;

public interface ICloudProviderService
{
    Task<List<Service>> GetServices(ServiceFilter filter, CancellationToken cancellationToken);

    Task<Service> GetServiceDetail( CancellationToken cancellationToken);//configuratrion

    Task UpdateResourceThrougput(Service service, CancellationToken cancellationToken);
}