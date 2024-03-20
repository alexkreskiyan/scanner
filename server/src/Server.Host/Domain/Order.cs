using System;
using System.Collections.Generic;

namespace Server.Host.Domain;

public class Order
{
    public Guid Id { get; private init; }
    public OrderStatus Status { get; private init; }
    public List<DocumentTypeConfiguration> DocumentTypes { get; private init; } = new();
    public List<Guid> Files { get; private init; } = new();
    public List<Document> Documents { get; private init; } = new();
}