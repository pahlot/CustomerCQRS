using CustomerCQRS.Core.Common;
using CustomerCQRS.Core.Domain;

namespace CustomerCQRS.Core.Events
{
    public class CustomerDeletedEvent : DomainEvent
    {
        public Customer Entity { get; }

        public CustomerDeletedEvent(Customer customer)
        {
            Entity = customer;
        }
    }
}
