using CustomerCQRS.Infrastructure.Customers.Queries.FindCustomer;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerCQRS.Tests.Infrastructure
{
    public class FindCustomerQueryTest : TestFixtureBase
    {
        [Fact]
        public async Task CanSearchForCustomerFirstOrLastName()
        {
            // Arrange
            FindCustomerQueryHandler handler = new FindCustomerQueryHandler(_dbContext.Object, _mapper);
            var search = new FindCustomerQuery()
            {
                NameSearch = "Jack"
            };


            // Act
            var result = await handler.Handle(search, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CanSearchFirstNameOrLastNameCaseInsensitive()
        {
            // Arrange
            var cancellationToken = new CancellationToken();

            FindCustomerQueryHandler handler = new FindCustomerQueryHandler(_dbContext.Object, _mapper);
            var search = new FindCustomerQuery()
            {
                NameSearch = "ja"
            };


            // Act
            var result = await handler.Handle(search, cancellationToken);

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CanSearchFirstName()
        {
            // Arrange
            var cancellationToken = new CancellationToken();

            FindCustomerQueryHandler handler = new FindCustomerQueryHandler(_dbContext.Object, _mapper);
            var search = new FindCustomerQuery()
            {
                NameSearch = "Nicolas"
            };


            // Act
            var result = await handler.Handle(search, cancellationToken);

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task CanSearchLastName()
        {
            // Arrange
            var cancellationToken = new CancellationToken();

            FindCustomerQueryHandler handler = new FindCustomerQueryHandler(_dbContext.Object, _mapper);
            var search = new FindCustomerQuery()
            {
                NameSearch = "cage"
            };


            // Act
            var result = await handler.Handle(search, cancellationToken);

            // Assert
            Assert.Single(result);
        }
    }
}
