using SharedLibrary.EventModels;
using SharedLibrary.Messaging;
using System.Text.Json;

namespace NotificationService.Handlers
{
    public class PaymentProcessedEventHandler
    {
        private readonly IEventBus _eventBus;

        public PaymentProcessedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Handle(PaymentProcessedEvent paymentProcessedEvent)
        {
            // Business logic for sending notifications
            if (paymentProcessedEvent.PaymentSuccess)
            {
                Console.WriteLine($"Sending notification: Payment successful for Ticket ID: {JsonSerializer.Serialize(paymentProcessedEvent)}");
            }
        }
    }
}
