using System;
using System.Threading.Tasks;
using Extensions.Data;
using Server.Application.Services;
using Server.Db.Repositories;
using Server.Domain;

namespace Server.Application.Internal.Services;

internal class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<Guid>> CreateAsync(Order order)
    {
        var result = await _orderRepository.CreateAsync(order);

        return result.IsSuccess ? Result.Ok(order.Id) : Result.From(result, Guid.Empty);
    }
}
