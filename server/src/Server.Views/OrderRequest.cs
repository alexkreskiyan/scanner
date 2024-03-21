using System.Collections.Generic;

namespace Server.Views;

public class OrderRequest
{
    public List<string> DocumentTypes { get; init; } = new();
}
