namespace TicketBookingService.Models
{
    public class TicketPurchaseRequest
    {
        public string UserEmail { get; set; }
        public decimal Amount { get; set; }
    }
}
