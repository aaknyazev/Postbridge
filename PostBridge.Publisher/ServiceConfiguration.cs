using Microsoft.Extensions.DependencyInjection;
using PostBridge.Publisher.Service;

namespace PostBridge.Publisher
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddPublisher(this IServiceCollection services)
        {
            return services
                .AddScoped<IPostmessageService, PostmessageService>()
                .AddScoped<IMessageResolver, MessageResolver>();
        }
    }
}
