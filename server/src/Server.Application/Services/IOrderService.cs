using System;
using System.Threading.Tasks;
using Extensions.Data;
using Server.Domain;

namespace Server.Application.Services;

public interface IOrderService
{
    Task<Result<Guid>> CreateAsync(Order order);
}
