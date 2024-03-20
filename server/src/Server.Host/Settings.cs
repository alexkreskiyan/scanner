using System.Collections.Generic;
using Server.Host.Domain;

namespace Server.Host;

public class Settings
{
    public string ConnectionString { get; set; } = string.Empty;
    public List<string> DocumentTypes { get; set; } = new();
    public Dictionary<string, DocumentFieldConfiguration> DocumentFields { get; set; } = new();
    public List<string> DocumentPages { get; set; } = new();
}
