using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Db.Internal.Configurations;

public static class DocumentPageConfiguration
{
    public static void Configure(this EntityTypeBuilder<DocumentPage> builder)
    {
        builder.ToTable("document_pages");
        builder.HasKey(x => x.Id);
        builder.HasOne<Document>().WithMany(x => x.Pages).HasForeignKey(x => x.DocumentId);
    }
}
