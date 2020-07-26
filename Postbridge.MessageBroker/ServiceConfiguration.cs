using Microsoft.Extensions.DependencyInjection;
using Postbridge.MessageBroker.Bus;
using Postbridge.MessageBroker.Factories;

namespace Postbridge.MessageBroker
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services)
        {
            return services
                .AddScoped<INatsConnectorFactory, NatsConnectorFactory>()
                .AddScoped<ITransitManager, TransitManager>();
        }
    }
}
