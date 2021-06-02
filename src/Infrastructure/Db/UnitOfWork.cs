using System.Threading.Tasks;

namespace Infrastructure.Db
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DDDContext _context;

        public UnitOfWork(DDDContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
