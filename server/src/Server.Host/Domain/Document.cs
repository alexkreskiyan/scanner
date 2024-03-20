using System;
using System.Collections.Generic;

namespace Server.Host.Domain;

public class Document
{
    public Guid Id { get; private init; }
    public Guid ApplicationId { get; private init; }
    public Guid TypeId { get; private init; }
    public DocumentTypeConfiguration Type { get; private init; } = default!;
    public List<DocumentField> Fields { get; private init; } = new();
    public List<DocumentPage> Pages { get; private init; } = new();
}
