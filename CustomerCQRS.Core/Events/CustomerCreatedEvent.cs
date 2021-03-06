using CustomerCQRS.Core.Common;
using CustomerCQRS.Core.Domain;

namespace CustomerCQRS.Core.Events
{
    public class CustomerCreatedEvent : DomainEvent
    {
        public Customer Entity { get; }

        public CustomerCreatedEvent(Customer customer)
        {
            Entity = customer;
        }
    }
}
