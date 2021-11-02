using CustomerCQRS.Core.Common;
using CustomerCQRS.Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCQRS.Infrastructure.Customers.EventHandlers
{
    public class CustomerCreatedEventHandler : INotificationHandler<DomainEventNotification<CustomerCreatedEvent>>
    {
        private readonly ILogger<CustomerCreatedEventHandler> _logger;

        public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CustomerCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event Fired: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }

    public class CustomerDeletedEventHandler : INotificationHandler<DomainEventNotification<CustomerDeletedEvent>>
    {
        private readonly ILogger<CustomerCreatedEventHandler> _logger;

        public CustomerDeletedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CustomerDeletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event Fired: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
