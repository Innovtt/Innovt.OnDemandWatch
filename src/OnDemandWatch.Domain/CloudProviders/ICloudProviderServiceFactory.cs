namespace OnDemandWatch.Domain.CloudProviders;

public interface ICloudProviderServiceFactory
{
    ICloudProviderService? CreateCloudService(CloudProvider provider);
}