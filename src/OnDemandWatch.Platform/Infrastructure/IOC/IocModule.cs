using Innovt.Core.CrossCutting.Ioc;
using Innovt.Core.CrossCutting.Log;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnDemandWatch.Domain.CloudProviders;
using OnDemandWatch.Platform.Infrastructure.CloudProviders;

namespace OnDemandWatch.Platform.Infrastructure.IOC

{
    public class IocModule : IOCModule
    {
        public IocModule(IConfiguration configuration)
        {
            var services = GetServices();

            services.AddSingleton<ILogger, Innovt.CrossCutting.Log.Serilog.Logger>();
            services.AddSingleton<ICloudProviderServiceFactory, CloudProviderFactory>();
        }
    }
}
