using System;

namespace Server.Host.Domain;

public class DocumentPage
{
    public Guid Id { get; private init; }
    public Guid TypeId { get; set; } = new();
    public DocumentPageConfiguration Type { get; set; } = new();
    public Guid FileId { get; set; }
}
