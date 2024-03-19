using System;

namespace Server.Host.Domain;

public class Field
{
    public Guid Id { get; private init; }
    public string Name { get; private init; } = string.Empty;
    public FieldConfiguration Configuration { get; private init; } = default!;

    public Field(Guid id, string name, FieldConfiguration configuration)
    {
        Id = id;
        Name = name;
    }

    private Field() { }
}
