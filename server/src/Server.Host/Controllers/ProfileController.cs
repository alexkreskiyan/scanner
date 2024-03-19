using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Host.Views;

namespace Server.Host.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
public class ProfileController : ControllerBase
{
    [HttpPost("parse")]
    [ProducesResponseType(typeof(ProfileInitResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Parse(
        [FromBody] ProfileParseRequest request,
        CancellationToken ct
    )
    {
        return Ok(new ProfileInitResponse());
    }

    [HttpPost("init")]
    [ProducesResponseType(typeof(ProfileInitResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Init(
        [FromBody] ProfileInitRequest request,
        CancellationToken ct
    )
    {
        return Ok(new ProfileInitResponse());
    }
}
