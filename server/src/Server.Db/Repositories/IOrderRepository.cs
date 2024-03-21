using System.Threading.Tasks;
using Extensions.Data;
using Server.Domain;

namespace Server.Db.Repositories;

public interface IOrderRepository
{
    Task<Result> CreateAsync(Order order);
}
