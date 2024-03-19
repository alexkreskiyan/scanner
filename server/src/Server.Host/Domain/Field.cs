using System;

namespace Server.Host.Domain;

public class Field
{
    public Guid Id { get; private init; }
    public string Name { get; private init; } = string.Empty;

    public Field(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    private Field() { }
}
