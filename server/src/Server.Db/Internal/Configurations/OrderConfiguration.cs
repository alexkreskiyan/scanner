using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Db.Internal.Configurations;

public static class OrderConfiguration
{
    public static void Configure(this EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(x => x.Id);
        // builder.OwnsOne(x => x.DocumentTypes, x => x.ToJson());
        // builder.OwnsOne(x => x.Files, x => x.ToJson());
        builder.HasMany(x => x.Documents).WithOne().HasForeignKey(x => x.OrderId);
    }
}
