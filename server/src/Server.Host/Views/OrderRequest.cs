using System;

namespace Server.Host.Views;

public class OrderRequest
{
    public string[] Fields { get; init; } = Array.Empty<string>();
}
