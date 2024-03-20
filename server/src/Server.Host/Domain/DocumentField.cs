using System;

namespace Server.Host.Domain;

public class DocumentField
{
    public Guid Id { get; private init; }
    public Guid DocumentId { get; private init; }
    public Guid TypeId { get; private init; }
    public DocumentFieldConfiguration Type { get; private init; } = default!;
    public string Value { get; private init; } = string.Empty;
}
