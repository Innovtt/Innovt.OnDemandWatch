// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Platform

using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Platform.Infrastructure.CloudProviders;

public class CloudProviderFactory: ICloudProviderServiceFactory
{
    public ICloudProviderService? CreateCloudService(CloudProvider provider)
    {
        if (provider == null) throw new ArgumentNullException(nameof(provider));
        

        return provider is Aws ? new AwsProviderService() : null;
    }
}