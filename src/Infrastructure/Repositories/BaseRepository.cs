using Domain.Abstract;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
    {
        private readonly DDDContext _context;

        public BaseRepository(DDDContext context)
        {
            _context = context;
        }

        public TAggregate Add(TAggregate aggregate)
        {
            return _context.Set<TAggregate>().Add(aggregate).Entity;
        }

        public TAggregate Update(TAggregate aggregate)
        {
            _context.Entry(aggregate).State = EntityState.Modified;

            return aggregate;
        }
    }
}
