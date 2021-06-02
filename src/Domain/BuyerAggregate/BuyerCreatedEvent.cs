using MediatR;

namespace Domain.BuyerAggregate
{
    public class BuyerCreatedEvent : INotification
    {
        public Buyer Buyer { get; }

        public BuyerCreatedEvent(Buyer buyer)
        {
            Buyer = buyer;
        }
    }
}
