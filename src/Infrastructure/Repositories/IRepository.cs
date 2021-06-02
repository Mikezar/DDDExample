using Domain.Abstract;

namespace Infrastructure.Repositories
{
    public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
    {
        TAggregate Add(TAggregate aggregate);
        TAggregate Update(TAggregate aggregate);
    }
}