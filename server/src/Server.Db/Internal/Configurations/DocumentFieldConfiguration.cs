using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Db.Internal.Configurations;

public static class DocumentFieldConfiguration
{
    public static void Configure(this EntityTypeBuilder<DocumentField> builder)
    {
        builder.ToTable("document_fields");
        builder.HasKey(x => x.Id);
        builder.HasOne<Document>().WithMany(x => x.Fields).HasForeignKey(x => x.DocumentId);
    }
}
