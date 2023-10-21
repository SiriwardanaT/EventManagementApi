using System;
using System.Collections.Generic;

namespace SalesManagementAPI.Models
{
    public partial class TicketCustomer
    {
        public TicketCustomer()
        {
          
        }
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime BuyDate { get; set; }
        public int? NumberOfTicket { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
