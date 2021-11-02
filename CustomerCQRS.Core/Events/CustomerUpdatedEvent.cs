using CustomerCQRS.Core.Common;
using CustomerCQRS.Core.Domain;

namespace CustomerCQRS.Core.Events
{
    public class CustomerUpdatedEvent : DomainEvent
    {
        public Customer Entity { get; }

        public CustomerUpdatedEvent(Customer customer)
        {
            Entity = customer;
        }
    }
}
