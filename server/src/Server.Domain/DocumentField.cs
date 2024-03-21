using System;

namespace Server.Domain;

public class DocumentField
{
    public Guid Id { get; private init; }
    public Guid DocumentId { get; private init; }
    public string Type { get; private init; } = string.Empty;
    public string Value { get; private init; } = string.Empty;
}
