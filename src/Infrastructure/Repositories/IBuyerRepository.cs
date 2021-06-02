using Domain.BuyerAggregate;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        Task<Buyer> GetBuyerByIdAsync(int buyerId);
    }
}
