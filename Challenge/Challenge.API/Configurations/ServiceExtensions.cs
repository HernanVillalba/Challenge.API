using Microsoft.EntityFrameworkCore;

namespace Challenge.API.Configurations;

public static class ServiceExtensions
{
    public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
    }

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ChallengeDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
    }

    public static void ConfigureDependencies(this IServiceCollection services)
    {

    }
}
