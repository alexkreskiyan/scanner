using System.IO;
using System.Text.Json;

namespace Server.Host.TestClient;

public class TestSettings
{
    public static TestSettings Current { get; }

    static TestSettings()
    {
        var opts = new JsonSerializerOptions();
        opts.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        var rawSettings = File.ReadAllText(Path.Combine("settings", "testsettings.json"));
        Current = JsonSerializer.Deserialize<TestSettings>(rawSettings, opts)!;
    }

    public string Url { get; init; } = string.Empty;
    public int ResponseTimeout { get; init; }
}
