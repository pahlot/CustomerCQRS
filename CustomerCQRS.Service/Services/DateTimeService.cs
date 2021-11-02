using CustomerCQRS.Core.Common;
using System;

namespace CustomerCQRS.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
