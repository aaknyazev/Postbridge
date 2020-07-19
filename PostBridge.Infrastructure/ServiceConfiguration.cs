using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostBridge.Domain.Postmessage;
using PostBridge.Infrastructure.Contexts;
using PostBridge.Infrastructure.RepositoryImplementations;

namespace PostBridge.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDbContext<PostBridgeMsSqlServerContext>(options => options.UseLazyLoadingProxies()
                    .UseSqlServer(AppSettings.ConnectionMsSqlServerString))

            .AddScoped<IPostmessageRepository, PostmessageRepository>();
        }
    }
}