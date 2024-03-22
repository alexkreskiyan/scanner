using System.Collections.Generic;
using Server.Domain;

namespace Server.Application.Services;

public interface IDictionaryService
{
    IReadOnlyDictionary<string, DocumentConfiguration> GetDocuments();
}
