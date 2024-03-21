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

    public IReadOnlyCollection<string> GetDocumentTypes()
    {
        return _settings.DocumentTypes;
    }

    public IReadOnlyDictionary<string, DocumentFieldConfiguration> GetDocumentFields()
    {
        return _settings.DocumentFields;
    }

    public IReadOnlyCollection<string> GetDocumentPages()
    {
        return _settings.DocumentPages;
    }
}
