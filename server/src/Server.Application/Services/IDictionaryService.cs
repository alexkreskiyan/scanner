using System.Collections.Generic;
using Server.Domain;

namespace Server.Application.Services;

public interface IDictionaryService
{
    IReadOnlyCollection<string> GetDocumentTypes();
    IReadOnlyDictionary<string, DocumentFieldConfiguration> GetDocumentFields();
    IReadOnlyCollection<string> GetDocumentPages();
}
