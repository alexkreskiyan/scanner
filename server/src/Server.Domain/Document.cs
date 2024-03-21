using System;
using System.Collections.Generic;

namespace Server.Domain;

public class Document
{
    public Guid Id { get; private init; }
    public Guid OrderId { get; private init; }
    public string Type { get; private init; } = default!;
    public List<DocumentField> Fields { get; private init; } = new();
    public List<DocumentPage> Pages { get; private init; } = new();
}
