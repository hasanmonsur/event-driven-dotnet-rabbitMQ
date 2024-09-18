using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.EventModels
{
    public class PaymentProcessedEvent
    {
        public Guid TicketId { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
