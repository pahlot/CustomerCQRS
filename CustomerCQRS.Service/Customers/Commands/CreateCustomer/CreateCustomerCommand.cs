using AutoMapper;
using CustomerCQRS.Core.Domain;
using CustomerCQRS.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCQRS.Infrastructure.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer()
            {
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
