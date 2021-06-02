using Application.Queries.ViewModels;
using MediatR;

namespace Application.Queries
{
    public class GetBuyerByIdQuery : IRequest<BuyerViewModel>
    {
        public int Id { get; }

        public GetBuyerByIdQuery(int buyerId)
        {
            Id = buyerId;
        }
    }
}
