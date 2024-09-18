using Microsoft.AspNetCore.Mvc;
using SharedLibrary.EventModels;
using SharedLibrary.Messaging;
using System.Net.Sockets;
using System.Text.Json;
using TicketBookingService.Models;

namespace TicketBookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TicketController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public TicketController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpPost("purchase")]
        public IActionResult PurchaseTicket([FromBody] TicketPurchaseRequest request)
        {
            // Business logic for purchasing ticket (saving to database, etc.)

            var ticketPurchasedEvent = new TicketPurchasedEvent
            {
                TicketId = Guid.NewGuid(),
                UserEmail = request.UserEmail,
                Amount = request.Amount
            };

            Console.WriteLine($"Processing Send Data: {JsonSerializer.Serialize(ticketPurchasedEvent)}");

            _eventBus.Publish("TicketPurchasedQueue", ticketPurchasedEvent);

            return Ok(new { Message = "Ticket purchased successfully!" });
        }
    }
}
