using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Host.Views;

namespace Server.Host.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
public class FieldsController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FieldResponse[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> List(CancellationToken ct)
    {
        return Ok(Array.Empty<FieldResponse>());
    }
}
