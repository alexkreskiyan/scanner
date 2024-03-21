using System;
using System.Collections.Generic;

namespace Server.Domain;

public class Order
{
    public Guid Id { get; private init; }
    public OrderStatus Status { get; private init; }
    public List<string> DocumentTypes { get; private init; } = new();
    public List<Guid> Files { get; private init; } = new();
    public List<Document> Documents { get; private init; } = new();
}
