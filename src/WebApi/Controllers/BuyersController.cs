using Application.Commands.BuyerCommands;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebApi.Dtos.Buyer;

namespace WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class BuyersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BuyersController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{buyerId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBuyer(int buyerId)
        {
            var buyer = await _mediator.Send(new GetBuyerByIdQuery(buyerId));

            if (buyer == null)
                return NotFound();

            var mapped = _mapper.Map<BuyerDto>(buyer);

            return Ok(mapped);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddBuyer([FromBody] AddBuyerDto dto)
        {
            var result = await _mediator.Send(new AddBuyerCommand(dto.Name, dto.Email));

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
