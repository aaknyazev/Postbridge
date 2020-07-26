using Microsoft.Extensions.DependencyInjection;
using PostBridge.Reader.Consumers;

namespace PostBridge.Reader
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddReader(this IServiceCollection services)
        {
            return services
                .AddScoped<IPostmessageConsumer, PostmessageConsumer>();
        }
    }
}
