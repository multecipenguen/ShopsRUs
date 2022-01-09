using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Application.Discounts.Commands;
using ShopsRUs.Application.Discounts.Models;
using ShopsRUs.Application.Discounts.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.Api.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IMapper _mapper;

        public DiscountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("discounts")]
        [ProducesResponseType(typeof(List<DiscountDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDiscounts()
        {
            return Ok(await Mediator.Send(new GetAllDiscountQuery()));
        }

        [HttpGet("discount/{type}")]
        [ProducesResponseType(typeof(DiscountDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDiscountByType(string type)
        {
            var result = await Mediator.Send(new GetDiscountbyTypeQuery(type));

            return result.Match<IActionResult>(x => Ok(x), x => NotFound(x.Description));
        }

        [HttpPost("discount")]
        [ProducesResponseType(typeof(DiscountDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto dto)
        {
            var command = _mapper.Map<CreateDiscountCommand>(dto);

            var result = await Mediator.Send(command);

            return result.Match<IActionResult>(x => Ok(x), x => BadRequest(x.Description));
        }
    }
}
