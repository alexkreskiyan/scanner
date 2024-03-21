using System;
using System.Threading.Tasks;
using Extensions.Data;
using Microsoft.Extensions.Logging;
using Server.Db.Repositories;
using Server.Domain;

namespace Server.Db.Internal.Repositories;

internal class OrderRepository : IOrderRepository
{
    private readonly ServerContext _ctx;
    private readonly ILogger<OrderRepository> _logger;

    public OrderRepository(ServerContext ctx, ILogger<OrderRepository> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }

    public async Task<Result> CreateAsync(Order order)
    {
        await using var transaction = await _ctx.Database.BeginTransactionAsync();
        try
        {
            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync();
            await transaction.CommitAsync();

            return Result.Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "create failed");
            await transaction.RollbackAsync();
            return Result.Fail("Order create failed");
        }
    }
}
