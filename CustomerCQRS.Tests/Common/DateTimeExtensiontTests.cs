using CustomerCQRS.Core.Common;
using CustomerCQRS.Core.Extensions;
using Moq;
using System;
using Xunit;

namespace CustomerCQRS.Tests.Common
{
    public class DateTimeExtensiontTests
    {
        private readonly Mock<IDateTime> _dateTimeService;

        public DateTimeExtensiontTests()
        {
            _dateTimeService = new Mock<IDateTime>();
            _dateTimeService.Setup(x => x.Now).Returns(new DateTime(2021, 1, 1)); // 1st Jan 2021
        }

        [Theory]
        [InlineData(2021, 1, 3, 0)]
        [InlineData(2021, 12, 31, 0)]
        [InlineData(2020, 1, 1, 1)]
        [InlineData(2020, 1, 3, 1)]
        [InlineData(2020, 1, 2, 1)]
        [InlineData(2011, 1, 2, 10)]
        [InlineData(1971, 1, 2, 50)]
        [InlineData(1921, 1, 2, 100)]
        public void CanCalculateDate(int yearOfBirth, int monthOfBirth, int dayOfBirth, int expectedAge)
        {
            var dob = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
            Assert.Equal(expectedAge, dob.GetAge(_dateTimeService.Object));
        }
    }
}
