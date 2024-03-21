using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.Db.Internal;
using Server.Db.Internal.Repositories;
using Server.Db.Repositories;
using Server.Domain;

namespace Server.Db;

public static class ServicePack
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddDbContext<ServerContext>(
            (sp, options) =>
            {
                var connectionString = sp.GetRequiredService<Settings>().ConnectionString;
                options
                    .UseNpgsql(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSnakeCaseNamingConvention();
            }
        );
    }

    public static void Setup(IServiceProvider provider)
    {
        var settings = provider.GetRequiredService<Settings>();
        DbMigrator.Migrate(settings.ConnectionString, "public");
    }
}
