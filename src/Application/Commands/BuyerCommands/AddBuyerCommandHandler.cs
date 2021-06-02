using Domain.BuyerAggregate;
using Infrastructure.Db;
using Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.BuyerCommands
{
    internal sealed class AddBuyerCommandHandler : IRequestHandler<AddBuyerCommand, bool>
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IUnitOfWork _unitOfWotk;

        public AddBuyerCommandHandler(IBuyerRepository buyerRepository, IUnitOfWork unitOfWotk)
        {
            _buyerRepository = buyerRepository;
            _unitOfWotk = unitOfWotk;
        }

        public async Task<bool> Handle(AddBuyerCommand request, CancellationToken cancellationToken)
        {
            var buyer = new Buyer(request.Name, request.Email);

            _buyerRepository.Add(buyer);

            await _unitOfWotk.SaveChangesAsync();

            return true;
        }
    }
}
