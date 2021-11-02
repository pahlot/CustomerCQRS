using CustomerCQRS.Infrastructure.Customers.Commands;
using CustomerCQRS.Service.Common.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace CustomerCQRS.Tests.Infrastructure
{
    public class UpdateCustomerCommandTest : TestFixtureBase
    {
        [Fact]
        public async void CanUpdateCustomer()
        {
            //Arange
            UpdateCustomerCommandHandler handler = new UpdateCustomerCommandHandler(_dbContext.Object);
            UpdateCustomerCommand command = new UpdateCustomerCommand()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "Elon",
                LastName = "Musk",
                DateOfBirth = DateTime.Now.AddYears(-45)
            };

            //Act
            Unit result = await handler.Handle(command, new CancellationToken());

            var customerFromDb = _dbContext.Object.Customers.FirstOrDefault(x => x.FirstName.Equals(command.FirstName));

            //Asert
            Assert.IsType<Unit>(result);
            Assert.NotNull(customerFromDb);
        }

        [Fact]
        public async void ThrowsNullRefWhenIdNotFound()
        {
            //Arange
            UpdateCustomerCommandHandler handler = new UpdateCustomerCommandHandler(_dbContext.Object);
            UpdateCustomerCommand command = new UpdateCustomerCommand()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-0000000000E1"),
                FirstName = "Elon",
                LastName = "Musk",
                DateOfBirth = DateTime.Now.AddYears(-45)
            };

            //Asert
            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, new CancellationToken()));
        }
    }
}
