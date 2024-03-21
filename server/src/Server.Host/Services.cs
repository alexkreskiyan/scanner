using System;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Host;

internal static class Services
{
    public static void Register(this IServiceCollection services)
    {
        Db.Services.Register(services);
    }

    public static void Setup(this IServiceProvider provider)
    {
        Db.Services.Setup(provider);
    }
}
