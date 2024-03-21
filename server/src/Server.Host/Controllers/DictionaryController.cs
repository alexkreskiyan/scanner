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

    [HttpGet("document-types")]
    [ProducesResponseType(typeof(IReadOnlyCollection<string>), StatusCodes.Status200OK)]
    public IReadOnlyCollection<string> DocumentTypes()
    {
        return _dictionaryService.GetDocumentTypes();
    }

    [HttpGet("document-fields")]
    [ProducesResponseType(
        typeof(IReadOnlyDictionary<string, DocumentFieldConfigurationResponse>),
        StatusCodes.Status200OK
    )]
    public IReadOnlyDictionary<string, DocumentFieldConfigurationResponse> DocumentFields()
    {
        var fields = _dictionaryService.GetDocumentFields();

        return fields.ToDictionary(
            x => x.Key,
            x => new DocumentFieldConfigurationResponse
            {
                Label = x.Value.Label,
                DataType = x.Value.DataType
            }
        );
    }

    [HttpGet("document-pages")]
    [ProducesResponseType(typeof(IReadOnlyCollection<string>), StatusCodes.Status200OK)]
    public IReadOnlyCollection<string> DocumentPages()
    {
        return _dictionaryService.GetDocumentPages();
    }
}
