using System;

namespace Server.Host.Domain;

public class DocumentField
{
    public Guid Id { get; private init; }
    public Guid TypeId { get; set; } = new();
    public DocumentFieldConfiguration Type { get; set; } = new();
    public string Value { get; set; } = string.Empty;
}
