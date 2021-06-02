using Application.Queries.ViewModels;
using AutoMapper;
using WebApi.Dtos.Buyer;

namespace WebApi.MapProfiles
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<BuyerViewModel, BuyerDto>();
        }
    }
}
