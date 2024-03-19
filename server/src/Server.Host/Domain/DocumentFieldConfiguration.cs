using System;

namespace Server.Host.Domain;

public class DocumentFieldConfiguration
{
    public Guid Id { get; private init; }
    public string Type { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}
