using System;
using Microsoft.Extensions.DependencyInjection;
using Pathoschild.Http.Client;
using Server.Host.TestClient.Modules;

namespace Server.Host.TestClient;

public static class ServiceCollectionExtensions
{
    public static void AddTestClient(this IServiceCollection services)
    {
        // modules
        services.AddScoped<AppModule>();
        services.AddScoped<DictionaryModule>();
        services.AddScoped<OrderModule>();

        services.AddSingleton<IClient>(
            new FluentClient(TestSettings.Current.Url)
            {
                BaseClient =
                {
                    Timeout = TimeSpan.FromMilliseconds(TestSettings.Current.ResponseTimeout)
                }
            }
        );
    }
}
