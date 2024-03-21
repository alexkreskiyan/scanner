using System;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Internal.Services;
using Server.Application.Services;

namespace Server.Application;

public static class ServicePack
{
    public static void Register(IServiceCollection services)
    {
        services.AddSingleton<IDictionaryService, DictionaryService>();
        services.AddSingleton<IOrderService, OrderService>();
    }

    public static void Setup(IServiceProvider provider)
    {
        //
    }
}
