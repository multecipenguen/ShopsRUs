using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Application.Bills.Models;
using ShopsRUs.Application.Invoices.Models;
using ShopsRUs.Application.Invoices.Queries;
using System.Threading.Tasks;

namespace ShopsRUs.Api.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IMapper _mapper;

        public InvoiceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("invoice")]
        [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCutomerByName([FromQuery] BillDto dto)
        {

            var command = _mapper.Map<GetTotalInvoiceAmountQuery>(dto);

            var result = await Mediator.Send(command);

            return result.Match<IActionResult>(x => Ok(x), x => BadRequest(x.Description));
        }
    }
}
