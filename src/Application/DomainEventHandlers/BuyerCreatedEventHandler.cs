using Domain.BuyerAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEventHandlers
{
    internal sealed class BuyerCreatedEventHandler : INotificationHandler<BuyerCreatedEvent>
    {
        public async Task Handle(BuyerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Send email here

            await Task.CompletedTask;
        }
    }
}
