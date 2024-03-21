using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Domain;
using Server.Views;

namespace Server.Host.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
public class DictionaryController : ControllerBase
{
    private readonly Settings _settings;

    public DictionaryController(Settings settings)
    {
        _settings = settings;
    }

    [HttpGet("document-types")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public List<string> DocumentTypes()
    {
        return _settings.DocumentTypes;
    }

    [HttpGet("document-fields")]
    [ProducesResponseType(
        typeof(Dictionary<string, DocumentFieldConfigurationResponse>),
        StatusCodes.Status200OK
    )]
    public Dictionary<string, DocumentFieldConfigurationResponse> DocumentFields()
    {
        return _settings.DocumentFields.ToDictionary(
            x => x.Key,
            x => new DocumentFieldConfigurationResponse
            {
                Label = x.Value.Label,
                DataType = x.Value.DataType
            }
        );
    }

    [HttpGet("document-pages")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public List<string> DocumentPages()
    {
        return _settings.DocumentPages;
    }
}
