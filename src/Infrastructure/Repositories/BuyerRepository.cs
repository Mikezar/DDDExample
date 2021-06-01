using Domain.BuyerAggregate;
using Infrastructure.Db;

namespace Infrastructure.Repositories
{
    internal sealed class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(DDDContext context) : base(context)
        {
        }
    }
}
