namespace Domain.Abstract
{
    public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
    {
        TAggregate Add(TAggregate aggregate);
        TAggregate Update(TAggregate aggregate);
    }
}