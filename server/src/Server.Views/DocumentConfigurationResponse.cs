using System;
using System.Collections.Generic;

namespace Server.Views;

public class DocumentConfigurationResponse
{
    public IReadOnlyDictionary<string, DocumentFieldConfigurationResponse> Fields { get; set; } =
        new Dictionary<string, DocumentFieldConfigurationResponse>();
    public IReadOnlyCollection<string> Pages { get; set; } = Array.Empty<string>();
}
