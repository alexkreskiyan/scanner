using System.Collections.Generic;

namespace Server.Domain;

public class DocumentConfiguration
{
    public Dictionary<string, DocumentFieldConfiguration> Fields { get; set; } = new();
    public List<string> Pages { get; set; } = new();
}
