using Microsoft.Extensions.DependencyInjection;

namespace ChallengeTesting.Utils;

public abstract class TestClass<TService>
{
    protected readonly TService Service;

    protected TestClass()
    {
        var provider = ServiceBuilder.BuildServiceProvider();

        Service = provider.GetService<TService>();
    }

}