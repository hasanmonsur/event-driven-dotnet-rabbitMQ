using SharedLibrary.EventModels;
using SharedLibrary.Messaging;

namespace PaymentService.Services
{
    public class RabbitMQPaymentConsumer
    {
        private readonly IEventBus _eventBus;

        public RabbitMQPaymentConsumer(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void StartListening()
        {
            _eventBus.Subscribe<TicketPurchasedEvent>("TicketPurchasedQueue", HandleEvent);
        }

        private void HandleEvent(TicketPurchasedEvent ticketPurchasedEvent)
        {
            // Handle the event (e.g., process payment)
        }
    }
}
