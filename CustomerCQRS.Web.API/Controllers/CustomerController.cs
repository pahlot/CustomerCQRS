using CustomerCQRS.Infrastructure.Customers.Commands;
using CustomerCQRS.Infrastructure.Customers.Commands.DeleteCustomer;
using CustomerCQRS.Infrastructure.Customers.Queries.FindCustomer;
using CustomerCQRS.Infrastructure.Customers.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCQRS.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ISender _mediator;

        public CustomerController(ILogger<CustomerController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            var searchModel = new FindCustomerQuery()
            {
                NameSearch = "smith"
            };
            return await _mediator.Send(searchModel);
        }

        [HttpPost]
        public async Task<Guid> CreateCustomer(CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut()]
        public async Task<ActionResult> Update(UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }

        [HttpPost("search")]
        public async Task<IEnumerable<CustomerViewModel>> Search(FindCustomerQuery command)
        {
            return await _mediator.Send(command);
        }
    }
}
