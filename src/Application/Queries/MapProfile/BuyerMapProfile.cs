using Application.Queries.ViewModels;
using AutoMapper;
using Domain.BuyerAggregate;

namespace Application.Queries.MapProfile
{
    internal sealed class BuyerMapProfile : Profile
    {
        public BuyerMapProfile()
        {
            CreateMap<Buyer, BuyerViewModel>();
        }
    }
}
