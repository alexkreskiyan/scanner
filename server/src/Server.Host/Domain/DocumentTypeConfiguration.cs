using System;

namespace Server.Host.Domain;

public class DocumentTypeConfiguration
{
    public Guid Id { get; private init; }
    public string Type { get; set; } = string.Empty;

}
