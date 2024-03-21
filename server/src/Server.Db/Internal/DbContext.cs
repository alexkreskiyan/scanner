using Microsoft.EntityFrameworkCore;
using Server.Db.Internal.Configurations;
using Server.Domain;

namespace Server.Db.Internal;

internal class ServerContext : DbContext
{
    public DbSet<Document> Documents { get; private set; } = default!;
    public DbSet<DocumentField> DocumentFields { get; private set; } = default!;
    public DbSet<DocumentPage> Registrations { get; private set; } = default!;
    public DbSet<Order> Orders { get; private set; } = default!;

    public ServerContext(DbContextOptions<ServerContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        modelBuilder.Entity<Document>().Configure();
        modelBuilder.Entity<DocumentField>().Configure();
        modelBuilder.Entity<DocumentPage>().Configure();
        modelBuilder.Entity<Order>().Configure();
    }
}
