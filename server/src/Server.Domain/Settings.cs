using System.Collections.Generic;

namespace Server.Domain;

public class Settings
{
    public string ConnectionString { get; set; } = string.Empty;

    public Dictionary<string, DocumentConfiguration> Documents { get; set; } = new();
}