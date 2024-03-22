using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Services;
using Server.Views;

namespace Server.Host.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
public class DictionaryController : ControllerBase
{
    private readonly IDictionaryService _dictionaryService;

    public DictionaryController(IDictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }

    [HttpGet("documents")]
    [ProducesResponseType(
        typeof(IReadOnlyDictionary<string, DocumentConfigurationResponse>),
        StatusCodes.Status200OK
    )]
    public IReadOnlyDictionary<string, DocumentConfigurationResponse> Documents()
    {
        var documents = _dictionaryService.GetDocuments();

        return documents.ToDictionary(
            x => x.Key,
            x => new DocumentConfigurationResponse
            {
                Fields = x.Value.Fields.ToDictionary(
                    f => f.Key,
                    f => new DocumentFieldConfigurationResponse
                    {
                        Label = f.Value.Label,
                        DataType = f.Value.DataType,
                        DisplayOrder = f.Value.DisplayOrder
                    }
                ),
                Pages = x.Value.Pages
            }
        );
    }
}
