using System;
using System.Collections.Generic;

namespace Server.Host.Domain;

public class Document
{
    public Guid Id { get; private init; }
    public Guid TypeId { get; set; } = new();
    public DocumentTypeConfiguration Type { get; set; } = new();
    public List<DocumentField> Fields { get; set; } = new();
    public List<DocumentPage> Pages { get; set; } = new();
}
