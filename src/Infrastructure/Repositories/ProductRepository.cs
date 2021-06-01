using Domain.ProductAggregate;
using Infrastructure.Db;

namespace Infrastructure.Repositories
{
    internal sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DDDContext context) : base(context)
        {
        }
    }
}
