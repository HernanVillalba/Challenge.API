using Challenge.API.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace ChallengeTesting.Utils
{
    public static class ServiceBuilder
    {
        public static ServiceProvider BuildServiceProvider()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.json", false, false)
                .AddUserSecrets("userSecretsId");

            IConfigurationRoot configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services.ConfigureOptions(configuration);
            services.ConfigureServices(configuration);
            services.ConfigureDependencies();

            return services.BuildServiceProvider();
        }
    }
}