using CustomerCQRS.Core.Domain;
using CustomerCQRS.Core.Events;
using CustomerCQRS.Core.Interfaces;
using CustomerCQRS.Service.Common.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCQRS.Infrastructure.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest { 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Customers.FirstOrDefault(x => x.Id.Equals(request.Id));

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            entity.DateOfBirth = request.DateOfBirth;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            entity.DomainEvents.Add(new CustomerUpdatedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
