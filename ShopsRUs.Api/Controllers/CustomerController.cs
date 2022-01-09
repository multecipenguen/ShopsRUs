using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Application.Customers.Commands;
using ShopsRUs.Application.Customers.Models;
using ShopsRUs.Application.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("customers")]
        [ProducesResponseType(typeof(List<CustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCutomers()
        {
            return Ok(await Mediator.Send(new GetAllCustomerQuery()));
        }

        [HttpGet("customer/{id:guid}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCutomerById(Guid id)
        {
            var result = await Mediator.Send(new GetCustomerByIdQuery(id));

            return result.Match<IActionResult>(x => Ok(x), x => NotFound(x.Description));
        }

        [HttpGet("customer/{name}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCutomerByName(string name)
        {
            var result = await Mediator.Send(new GetCustomerByNameQuery(name));

            return result.Match<IActionResult>(x => Ok(x), x => NotFound(x.Description));
        }

        [HttpPost("customer")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCutomer(CreateCustomerDto dto)
        {
            var command = _mapper.Map<CreateCustomerCommand>(dto);

            var result = await Mediator.Send(command);

            return CreatedAtRoute("GetCustomer", new { result.Id }, result);
        }

    }
}
