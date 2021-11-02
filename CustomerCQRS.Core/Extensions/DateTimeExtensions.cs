using CustomerCQRS.Core.Common;
using System;

namespace CustomerCQRS.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime dateOfBirth, IDateTime dateTimeService)
        {
            var today = dateTimeService.Now;
            var age = today - dateOfBirth;
            return today.Year - today.AddDays(-age.Days).Year;
        }
    }
}
