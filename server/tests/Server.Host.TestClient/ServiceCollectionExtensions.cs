using Microsoft.Extensions.DependencyInjection;

namespace Server.Host.TestClient;

public static class ServiceCollectionExtensions
{
    public static void AddTestClient(this IServiceCollection services)
    {
        services.AddSingleton<Internal.TestClient>();
    }
}
