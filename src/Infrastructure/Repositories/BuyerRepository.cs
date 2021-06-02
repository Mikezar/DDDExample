using Domain.BuyerAggregate;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal sealed class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(DDDContext context) : base(context)
        {
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId)
        {
            return await Context.Buyers.FirstOrDefaultAsync(x => x.Id == buyerId);
        }
    }
}
