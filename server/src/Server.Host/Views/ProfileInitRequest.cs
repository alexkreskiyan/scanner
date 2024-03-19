using System;

namespace Server.Host.Views;

public class ProfileInitRequest
{
    public string[] Fields { get; init; } = Array.Empty<string>();
}
