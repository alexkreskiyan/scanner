using System.Collections.Generic;
using Server.Application.Services;
using Server.Domain;

namespace Server.Application.Internal.Services;

internal class DictionaryService : IDictionaryService
{
    private readonly Settings _settings;

    public DictionaryService(Settings settings)
    {
        _settings = settings;
    }

    public IReadOnlyDictionary<string, DocumentConfiguration> GetDocuments()
    {
        return _settings.Documents;
    }
}
