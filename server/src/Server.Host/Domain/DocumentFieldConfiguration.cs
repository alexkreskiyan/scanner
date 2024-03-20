using System;

namespace Server.Host.Domain;

public class DocumentFieldConfiguration
{
    public Guid Id { get; private init; }
    public string Type { get; private init; } = string.Empty;
    public string Label { get; private init; } = string.Empty;
    public string DataType { get; private init; } = string.Empty;
}
