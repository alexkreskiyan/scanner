using System;
using System.Threading;
using System.Threading.Tasks;
using Extensions.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Services;
using Server.Domain;
using Server.Views;

namespace Server.Host.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status400BadRequest)]
    public async Task<Result<Guid>> Create([FromBody] OrderRequest request)
    {
        var order = new Order
        {
            Status = OrderStatus.ManualProcessing,
            DocumentTypes = request.DocumentTypes
        };
        return await _orderService.CreateAsync(order);
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
