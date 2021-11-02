using CustomerCQRS.Infrastructure.Customers.Commands;
using System;
using System.Threading;
using Xunit;

namespace CustomerCQRS.Tests.Infrastructure
{
    public class CreateCustomerCommandTest : TestFixtureBase
    {
        [Fact]
        public async void CanCreateCustomer()
        {
            //Arange
            CreateCustomerCommand command = new CreateCustomerCommand();
            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_dbContext.Object);

            //Act
            Guid result = await handler.Handle(command, new CancellationToken());

            //Asert
            Assert.IsType<Guid>(result);
        }
    }
}
