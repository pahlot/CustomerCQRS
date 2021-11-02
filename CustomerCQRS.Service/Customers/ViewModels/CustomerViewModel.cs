using CustomerCQRS.Core.Domain;
using CustomerCQRS.Infrastructure.Common;
using System;

namespace CustomerCQRS.Infrastructure.Customers.ViewModels
{
    public class CustomerViewModel : IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
