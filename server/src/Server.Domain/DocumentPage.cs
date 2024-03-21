using System;

namespace Server.Domain;

public class DocumentPage
{
    public Guid Id { get; private init; }
    public Guid DocumentId { get; private init; }
    public string Type { get; private init; } = string.Empty;
    public Guid FileId { get; private init; }
}
