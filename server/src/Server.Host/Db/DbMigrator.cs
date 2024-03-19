using System;
using System.Reflection;
using DbUp;

namespace Server.Host.Db;

public static class DbMigrator
{
    public static void Migrate(string connectionString, string schema)
    {
        var result = DeployChanges
            .To.PostgresqlDatabase(connectionString)
            .WithTransactionPerScript()
            .WithVariablesDisabled()
            .WithExecutionTimeout(TimeSpan.FromSeconds(30))
            .JournalToPostgresqlTable(schema, "log_dbup_migrations")
            .WithScriptsEmbeddedInAssembly(
                Assembly.GetCallingAssembly(),
                s => s.Contains("Migrations")
            )
            .LogToConsole()
            .Build()
            .PerformUpgrade();

        if (!result.Successful)
        {
            throw new ApplicationException(result.ErrorScript + ":" + result.Error);
        }
    }
}
