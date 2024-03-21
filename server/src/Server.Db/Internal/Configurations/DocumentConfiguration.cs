using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Db.Internal.Configurations;

public static class DocumentConfiguration
{
    public static void Configure(this EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("documents");
        builder.HasKey(x => x.Id);
        builder.HasOne<Order>().WithMany(x => x.Documents).HasForeignKey(x => x.OrderId);
        builder.HasMany(x => x.Fields).WithOne().HasForeignKey(x => x.DocumentId);
        builder.HasMany(x => x.Pages).WithOne().HasForeignKey(x => x.DocumentId);
    }
}
