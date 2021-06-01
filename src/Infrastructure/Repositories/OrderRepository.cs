using Domain.OrderAggregate;
using Infrastructure.Db;

namespace Infrastructure.Repositories
{
    internal sealed class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DDDContext context) : base(context)
        {
        }
    }
}
