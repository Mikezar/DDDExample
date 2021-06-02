using Application.Queries.ViewModels;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.BuyerQueries
{
    internal sealed class GetBuyerByIdQueryHandler : IRequestHandler<GetBuyerByIdQuery, BuyerViewModel>
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IMapper _mapper;

        public GetBuyerByIdQueryHandler(IBuyerRepository buyerRepository, IMapper mapper)
        {
            _buyerRepository = buyerRepository;
            _mapper = mapper;
        }

        public async Task<BuyerViewModel> Handle(GetBuyerByIdQuery request, CancellationToken cancellationToken)
        {
            var buyer = await _buyerRepository.GetBuyerByIdAsync(request.Id);

            return _mapper.Map<BuyerViewModel>(buyer);
        }
    }
}
