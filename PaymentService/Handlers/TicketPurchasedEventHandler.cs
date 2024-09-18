using SharedLibrary.EventModels;
using SharedLibrary.Messaging;
using System.Text.Json;

namespace PaymentService.Handlers
{
    public class TicketPurchasedEventHandler
    {
        private readonly IEventBus _eventBus;

        public TicketPurchasedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }


        public void Handle(TicketPurchasedEvent ticketPurchasedEvent)
        {
            Console.WriteLine($"Processing payment for Ticket ID: {JsonSerializer.Serialize(ticketPurchasedEvent)}");
            // Business logic for payment processing
            var paymentProcessedEvent = new PaymentProcessedEvent
            {
                TicketId = ticketPurchasedEvent.TicketId,
                PaymentSuccess = true
            };

            // Publish PaymentProcessedEvent to RabbitMQ
            _eventBus.Publish("PaymentProcessedQueue", paymentProcessedEvent);

        }
    }
}
