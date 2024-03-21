using System;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Host;

internal static class ServicePack
{
    public static void Register(IServiceCollection services)
    {
        Application.ServicePack.Register(services);
        Db.ServicePack.Register(services);
    }

    public static void Setup(IServiceProvider provider)
    {
        Application.ServicePack.Setup(provider);
        Db.ServicePack.Setup(provider);
    }
}
