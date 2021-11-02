using CustomerCQRS.Core.Common;
using System;
using System.Collections.Generic;

namespace CustomerCQRS.Core.Domain
{
    public class Customer : EntityBase, IHasDomainEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Domain events, can have multiple domain events
        /// </summary>
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
