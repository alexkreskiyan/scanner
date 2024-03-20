using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Host.Domain;
using Server.Host.Views;

namespace Server.Host.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] OrderRequest request,
        CancellationToken ct
    )
    {
        return Ok(new OrderResponse());
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Complete([FromQuery] Guid id, CancellationToken ct)
    {
        return Ok(new OrderResponse());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken ct)
    {
        return Ok(new OrderResponse());
    }

    [HttpGet("todo")]
    [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTodo(CancellationToken ct)
    {
        return Ok(new OrderResponse());
    }
}
