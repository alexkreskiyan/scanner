using System;
using Microsoft.Extensions.DependencyInjection;
using Server.Host.Db;

namespace Server.Host;

internal static class Services
{
    public static void Register(this IServiceCollection services)
    {
        //
    }

    public static void Setup(this IServiceProvider provider)
    {
        var settings = provider.GetRequiredService<Settings>();
        DbMigrator.Migrate(settings.ConnectionString, "public");
    }
}
