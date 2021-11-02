using CustomerCQRS.Infrastructure.Customers.Queries.FindCustomer;
using CustomerCQRS.Infrastructure.Customers.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerCQRS.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerViewModel>> Index()
        {
            var searchModel = new FindCustomerQuery()
            {
                NameSearch = "smith"
            };
            return await _mediator.Send(searchModel);
        }
    }
}
