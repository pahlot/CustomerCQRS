using AutoMapper;
using AutoMapper.QueryableExtensions;
using CustomerCQRS.Core.Interfaces;
using CustomerCQRS.Infrastructure.Customers.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCQRS.Infrastructure.Customers.Queries.FindCustomer
{
    public class FindCustomerQuery : IRequest<IEnumerable<CustomerViewModel>>
    {
        /// <summary>
        /// Search value to search for the customers first or last name
        /// </summary>
        public string NameSearch { get; set; }
    }

    public class FindCustomerQueryHandler : IRequestHandler<FindCustomerQuery, IEnumerable<CustomerViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FindCustomerQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerViewModel>> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Where(x => x.FirstName.Contains(request.NameSearch, StringComparison.InvariantCultureIgnoreCase) || 
                                x.LastName.Contains(request.NameSearch, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(x => x.LastName)
                .ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
