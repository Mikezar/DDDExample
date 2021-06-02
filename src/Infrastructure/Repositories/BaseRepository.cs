using Domain.Abstract;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
    {
        protected readonly DDDContext Context;

        public BaseRepository(DDDContext context)
        {
            Context = context;
        }

        public TAggregate Add(TAggregate aggregate)
        {
            return Context.Set<TAggregate>().Add(aggregate).Entity;
        }

        public TAggregate Update(TAggregate aggregate)
        {
            Context.Entry(aggregate).State = EntityState.Modified;

            return aggregate;
        }
    }
}
