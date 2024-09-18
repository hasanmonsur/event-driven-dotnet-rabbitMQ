using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.EventModels
{
    public class TicketPurchasedEvent
    {
        public Guid TicketId { get; set; }
        public string? UserEmail { get; set; }
        public decimal Amount { get; set; }
    }
}
