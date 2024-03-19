using System;
using Server.Host.Domain;

namespace Server.Host.Views;

public class FieldResponse
{
    public Guid Id { get; private init; }
    public string Name { get; private init; } = string.Empty;
    public DocumentFieldConfiguration Configuration { get; private init; } = default!;
}
