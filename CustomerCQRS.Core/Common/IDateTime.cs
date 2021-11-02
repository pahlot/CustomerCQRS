using System;

namespace CustomerCQRS.Core.Common
{
    public interface IDateTime
    {
        public DateTime Now { get; }
    }
}
