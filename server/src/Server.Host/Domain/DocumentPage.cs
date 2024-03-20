using System;

namespace Server.Host.Domain;

public class DocumentPage
{
    public Guid Id { get; private init; }
    public Guid DocumentId { get; private init; }
    public Guid TypeId { get; private init; } = new();
    public DocumentPageConfiguration Type { get; private init; } = new();
    public Guid FileId { get; private init; }
}
