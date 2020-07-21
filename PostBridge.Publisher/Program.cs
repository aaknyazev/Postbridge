using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostBridge.Domain.Postmessage;
using PostBridge.Infrastructure;

namespace PostBridge.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddInfrastructure();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Core core = new Core(serviceProvider.GetService<IPostmessageRepository>());
  
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).ConfigureServices(services =>
            {
                services.AddHostedService<Core>();
            });
    }
}
