using Microsoft.Extensions.Configuration;
using System.IO;

namespace PostBridge.Infrastructure
{
    public static class AppSettings
    {
        private static readonly IConfigurationRoot _config;
        static AppSettings()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            _config = builder.Build();
        }

        public static string ConnectionMsSqlServerString => _config.GetConnectionString("DefaultMsSqlServerConnection");
    }
}
