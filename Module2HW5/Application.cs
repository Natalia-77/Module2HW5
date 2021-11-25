using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Service;
using Module2HW5.Service.Abstractions;

namespace Module2HW5
{
    public class Application
    {
        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, LoggerService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<Actions>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
            var starter = serviceProvider.GetService<Starter>();
            starter.RunActions();
        }
    }
}
