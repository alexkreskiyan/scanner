using System;
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
    [HttpPost("request")]
    [ProducesResponseType(typeof(ProfileInitResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Init(
        [FromBody] ProfileInitRequest model,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
