using System;
using Microsoft.Extensions.DependencyInjection;
using Server.Db.Internal;
using Server.Domain;

namespace Server.Db;

public static class Services
{
    public static void Register(IServiceCollection services)
    {
        //
    }

    public static void Setup(IServiceProvider provider)
    {
        var settings = provider.GetRequiredService<Settings>();
        DbMigrator.Migrate(settings.ConnectionString, "public");
    }
}
