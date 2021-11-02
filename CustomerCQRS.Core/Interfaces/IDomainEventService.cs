using CustomerCQRS.Core.Common;
using System.Threading.Tasks;

namespace CustomerCQRS.Core.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
