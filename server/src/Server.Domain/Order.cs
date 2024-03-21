using System;
using System.Collections.Generic;

namespace Server.Domain;

public class Order
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public OrderStatus Status { get; init; }
    public List<string> DocumentTypes { get; init; } = new();
    public List<Guid> Files { get; init; } = new();
    public List<Document> Documents { get; init; } = new();
}
