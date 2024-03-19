using System;

namespace Server.Host.Domain;

public class DocumentPageConfiguration
{
    public Guid Id { get; private init; }
    public string Type { get; set; } = string.Empty;
}
