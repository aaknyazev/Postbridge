using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Postbridge.MessageBroker;
using PostBridge.Infrastructure;
using System;

namespace PostBridge.Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services.AddInfrastructure();
                services.AddReader();
                services.AddMessageBroker();
                services.AddHostedService<Worker>();
            });
    }
}
